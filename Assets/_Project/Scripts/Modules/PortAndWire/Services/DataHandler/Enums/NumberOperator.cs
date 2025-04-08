using UnityEngine;

namespace JOPA.Modules.PortAndWire.Data
{
    public enum NumberOperator
	{
		[InspectorName("Больше")]
		Greater,
		
		[InspectorName("Больше или равно")]
		GreaterEquals,
		
		[InspectorName("Меньше")]
		Less,
		
		[InspectorName("Меньше или равно")]
		LessEquals,
		
		[InspectorName("Равно")]
		Equals,
		
		[InspectorName("Не равно")]
		NotEquals
	}
}