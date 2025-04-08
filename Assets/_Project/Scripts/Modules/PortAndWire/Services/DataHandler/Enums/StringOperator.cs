using UnityEngine;

namespace JOPA.Modules.PortAndWire.Data
{
    public enum StringOperator
	{
		[InspectorName("Длиннее")]
		Longer,
		
		[InspectorName("Длиннее или сходное")]
		LongerSameLong,
		
		[InspectorName("Короче")]
		Shorter,
		
		[InspectorName("Короче или сходное")]
		ShorterSameLong,
		
		[InspectorName("Такое же длинное")]
		SameLong,
		
		[InspectorName("Другой длины")]
		NotSameLong,
		
		[InspectorName("Совпадает")]
		Equals,
		
		[InspectorName("Не совпадает")]
		NotEquals
	}
}