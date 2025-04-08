using UnityEngine;

namespace JOPA.Modules.PortAndWire.Data
{
    public enum ResultType
	{
		[InspectorName("Порт")]
		TargetPort,
		
		[InspectorName("Порт из списка")]
		PortList,
		
		[InspectorName("Любой порт")]
		AnyPort,
	}
}