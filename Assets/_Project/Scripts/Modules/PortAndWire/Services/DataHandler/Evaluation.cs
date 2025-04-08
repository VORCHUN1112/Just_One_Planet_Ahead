using UnityEngine;
using System;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[Serializable]
	[HorizontalGroup]
	public abstract class Evaluation<T, K>
	{
		[BoxGroup("Сравнение")]
		[LabelText("Оператор")]
		[SerializeField] protected T _operator;
		[BoxGroup("Сравнение")]
		[LabelText("Сравнить с")]
		[SerializeField] protected K _trueOption;
		
		public T Operator => _operator;
		public K Result => _trueOption;

		public abstract bool Evaluate(K shipInput);
	}

	[Serializable]
	public class BatteryEvaluation : Evaluation<NumberOperator, BatteryData>
	{
		public override bool Evaluate(BatteryData shipInput)
		{
			bool evaluationResult = DataComparator.Compare(shipInput, Result, Operator);
			return evaluationResult;
		}
	}

	[Serializable]
	public class ConnectorEvaluation : Evaluation<NumberOperator, ConnectorData>
	{
		public override bool Evaluate(ConnectorData shipInput)
		{
			bool evaluationResult = DataComparator.Compare(shipInput, Result, Operator);
			return evaluationResult;
		}
	}

	[Serializable]
	public class WireMaterialEvaluation : Evaluation<InstanceOperator, WireMaterialData>
	{
		public override bool Evaluate(WireMaterialData shipInput)
		{
			bool evaluationResult = DataComparator.Compare(shipInput, Result, Operator);
			return evaluationResult;
		}
	}

	[Serializable]
	public class ShipSerialEvaluation : Evaluation<StringOperator, ShipSerialData>
	{
		public override bool Evaluate(ShipSerialData shipInput)
		{
			bool evaluationResult = DataComparator.Compare(shipInput, Result, Operator);
			return evaluationResult;
		}
	}
}