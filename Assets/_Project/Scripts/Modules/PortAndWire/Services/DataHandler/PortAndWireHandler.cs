using System;
using UnityEngine;
using System.Collections.Generic;
using Alchemy.Inspector;
using Alchemy.Serialization;
using JOPA.Modules.PortAndWire.Services;

namespace JOPA.Modules.PortAndWire.Data
{
	[AlchemySerialize]
	public partial class PortAndWireHandler : MonoBehaviour
	{	
		[BoxGroup("Данные корабля")]
		[SerializeField] private ShipSerialData _serial;

		[BoxGroup("Данные корабля")]
		[SerializeField] private BatteryData _battery;

		[BoxGroup("Последнее подключение")]
		[ReadOnly]
		[SerializeField] private Connection _connection;

		[BoxGroup("Пресеты проводов")]
		[AlchemySerializeField, NonSerialized]
		[SerializeField] private Dictionary<ConnectorData, Condition> _presets = 
		new Dictionary<ConnectorData, Condition>();

		public static Action<Connection, bool> OnConnectionChecked;
		
		private void Start()
		{
			ConnectionHandler.OnConnected += CheckConnection;
		}
		
		private void OnDestroy()
		{
			ConnectionHandler.OnConnected -= CheckConnection;
		}
		
		public void CheckConnection(Connection connection)
		{
			_connection = connection;

			Condition currentCondition;
			bool presetExists = _presets.TryGetValue(connection.Connector, out currentCondition);
			
			if (!presetExists || currentCondition == null)
			{
				throw new Exception($"Нет условия для провода {connection.Port.Value}!");
			}

			EvaluationResult result = CheckCondition(currentCondition);
			bool connectionIsValid = HandleResult(result);

			OnConnectionChecked?.Invoke(connection, connectionIsValid);
		}
		
		private EvaluationResult CheckCondition(Condition condition)
		{
			EvaluationResult result = condition.ElseResult;

			foreach (Subcondition subcondition in condition.Subconditions)
			{
				bool isTrue = CheckSubcontidion(subcondition);
				if (!isTrue) continue;

				result = subcondition.Evaluation.Result;
				break;
			}
			
			return result;
		}
		
		private bool CheckSubcontidion(Subcondition subcondition)
		{
			ShipSerialData serial = _serial;
			BatteryData battery = _battery;
			WireMaterialData wire = _connection.WireMaterial;
			ConnectorData connector = _connection.Connector;

			InputArgument argument = subcondition.Argument;
			EvaluationNode evaluation = subcondition.Evaluation;

			bool result = false;
			
			switch (argument)
			{
				case InputArgument.ShipSerial:
					result = evaluation.Evaluate(serial);
					break;
					
				case InputArgument.BatteryLevel:
					result = evaluation.Evaluate(battery);
					break;
					
				case InputArgument.WireColor:
					result = evaluation.Evaluate(wire);
					break;
				
				case InputArgument.ConnectorID:
					result = evaluation.Evaluate(connector);
					break;
			}
			
			return result;
		}
		
		private bool HandleResult(EvaluationResult result)
		{
			bool isValid = false;
			
			PortData connectedPort = _connection.Port;
			ResultType resultType = result.ResultType;
			
			switch (resultType)
			{
				case ResultType.TargetPort:
					isValid = connectedPort.Equals(result.Port);
					break;

				case ResultType.PortList:
					isValid = result.PortList.Contains(connectedPort);
					break;

				case ResultType.AnyPort:
					isValid = true;
					break;
			}
			
			return isValid;
		}
	}
}