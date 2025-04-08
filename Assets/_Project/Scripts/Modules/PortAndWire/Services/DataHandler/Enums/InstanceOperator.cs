using UnityEngine;

namespace JOPA.Modules.PortAndWire.Data
{
    public enum InstanceOperator
	{
		[InspectorName("Совпадает")]
		Equals,
		
		[InspectorName("Не совпадает")]
		NotEquals
	}
}