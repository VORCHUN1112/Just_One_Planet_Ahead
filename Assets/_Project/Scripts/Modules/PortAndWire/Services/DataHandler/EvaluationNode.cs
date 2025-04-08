using UnityEngine;
using System;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[Serializable]
	[HorizontalGroup]
	public class EvaluationNode
	{
		[Group]
		[ShowIf(nameof(BatteryType))]
		[SerializeField] private BatteryEvaluation _battery;
		
		[Group]
		[ShowIf(nameof(ConnectorType))]
		[SerializeField] private ConnectorEvaluation _connector;
		
		[Group]
		[ShowIf(nameof(WireType))]
		[SerializeField] private WireMaterialEvaluation _material;
		
		[Group]
		[ShowIf(nameof(ShipSerialType))]
		[SerializeField] private ShipSerialEvaluation _serial;

		[Group]
		[Header("Result")]
		[SerializeField] private EvaluationResult _result;
		
		private InputArgument _nodeType;
		
		public BatteryEvaluation Battery => _battery;
		public ConnectorEvaluation Connector => _connector;
		public WireMaterialEvaluation Material => _material;
		public ShipSerialEvaluation Serial => _serial;
		public EvaluationResult Result => _result;
		public InputArgument NodeType => _nodeType;
		
		public bool BatteryType => _nodeType == InputArgument.BatteryLevel;
		public bool ConnectorType => _nodeType == InputArgument.ConnectorID;
		public bool WireType => _nodeType == InputArgument.WireColor;
		public bool ShipSerialType => _nodeType == InputArgument.ShipSerial;

		public void Init(InputArgument argument)
		{
			_nodeType = argument;
		}
		
		public void ClearInit(InputArgument argument)
		{
			_nodeType = argument;
			_battery = new BatteryEvaluation();
			_connector = new ConnectorEvaluation ();
			_material = new WireMaterialEvaluation ();
			_serial = new ShipSerialEvaluation ();
		}

		public bool Evaluate(BatteryData input)
		{
			bool result = _battery.Evaluate(input);
			return result;
		}

		public bool Evaluate(ConnectorData input)
		{
			bool result = _connector.Evaluate(input);
			return result;
		}
		
		public bool Evaluate(WireMaterialData input)
		{
			bool result = _material.Evaluate(input);
			return result;
		}
		
		public bool Evaluate(ShipSerialData input)
		{
			bool result = _serial.Evaluate(input);
			return result;
		}
	}
}