namespace JOPA.Modules.PortAndWire.Data
{
	public static class DataComparator
	{
		public static bool Compare(BatteryData shipInput, BatteryData targetResult, NumberOperator oper)
		{
			int shipValue = shipInput.Value;
			int targetValue = targetResult.Value;

			bool result = Compare(shipValue, targetValue, oper);
			return result;
		}

		public static bool Compare(ConnectorData shipInput, ConnectorData targetResult, NumberOperator oper)
		{
			int shipValue = int.Parse(shipInput.Value);
			int targetValue = int.Parse(targetResult.Value);

			bool result = Compare(shipValue, targetValue, oper);
			return result;
		}

		public static bool Compare(PortData shipInput, PortData targetResult, NumberOperator oper)
		{
			int shipValue = int.Parse(shipInput.Value);
			int targetValue = int.Parse(targetResult.Value);

			bool result = Compare(shipValue, targetValue, oper);
			return result;
		}

		public static bool Compare(ShipSerialData shipInput, ShipSerialData targetResult, StringOperator oper)
		{
			string shipValue = shipInput.Value;
			string targetValue = targetResult.Value;

			bool result = Compare(shipValue, targetValue, oper);
			return result;
		}

		public static bool Compare(WireMaterialData shipInput, WireMaterialData targetResult, InstanceOperator oper)
		{
			object shipValue = shipInput.Value;
			object targetValue = targetResult.Value;

			bool result = Compare(shipValue, targetValue, oper);
			return result;
		}


		public static bool Compare(int operand1, int operand2, NumberOperator numberOperator)
		{
			float fOperand1 = (float) operand1;
			float fOperand2 = (float) operand2;

			bool result = Compare(fOperand1, fOperand2, numberOperator);
			return result;
		}

		public static bool Compare(float operand1, float operand2, NumberOperator numberOperator)
		{
			bool result = false;

			switch (numberOperator)
			{
				case NumberOperator.Greater:
					result = operand1 > operand2;
					break;
					
				case NumberOperator.GreaterEquals:
					result = operand1 >= operand2;
					break;
					
				case NumberOperator.Less:
					result = operand1 < operand2;
					break;
					
				case NumberOperator.LessEquals:
					result = operand1 <= operand2;
					break;
					
				case NumberOperator.Equals:
					result = operand1 == operand2;
					break;
					
				case NumberOperator.NotEquals:
					result = operand1 != operand2;
					break;
			}

			return result;
		}

		public static bool Compare(string operand1, string operand2, StringOperator stringOperator)
		{
			bool result = false;
			
			int length1 = operand1.Length;
			int length2 = operand2.Length;
			
			switch (stringOperator)
			{
				case StringOperator.Longer:
					result = length1 > length2;
					break;
					
				case StringOperator.LongerSameLong:
					result = length1 > length2 || length1 == length2;
					break;
					
				case StringOperator.Shorter:
					result = length1 < length2;
					break;
					
				case StringOperator.ShorterSameLong:
					result = length1 < length2 || length1 == length2; ;
					break;
					
				case StringOperator.SameLong:
					result = length1 == length2;
					break;

				case StringOperator.NotSameLong:
					result = length1 != length2;
					break;

				case StringOperator.Equals:
					result = operand1 == operand2;
					break;
					
				case StringOperator.NotEquals:
					result = operand1 != operand2;
					break;
			}

			return result;
		}

		public static bool Compare(object operand1, object operand2, InstanceOperator instanceOperator)
		{
			bool result = false;

			switch (instanceOperator)
			{
				case InstanceOperator.Equals:
					result = operand1 == operand2;
					break;
					
				case InstanceOperator.NotEquals:
					result = operand1 != operand2;
					break;
			}

			return result;
		}
	}
}