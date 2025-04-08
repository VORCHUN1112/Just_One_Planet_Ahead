using UnityEngine;

namespace JOPA.Modules.PortAndWire.Data
{
    public enum InputArgument
	{
		[InspectorName("Имя корабля")]
		ShipSerial,
		
		[InspectorName("Заряд батареи")]
		BatteryLevel,
		
		[InspectorName("Номер провода")]
		ConnectorID,
		
		[InspectorName("Цвет провода")]
		WireColor,
	}
}