using UnityEngine;

namespace JOPA.Modules.PortAndWire
{

	public class StandardPort: Port
	{
		[Header("References")]
		[SerializeField] private Transform _connectionPoint;
		[SerializeField] private MeshRenderer _indicator;

		[Header("Indicator Colors")]
		[SerializeField] private Material _disconnected;
		[SerializeField] private Material _connected;
		[SerializeField] private Material _trueConnected;
		[SerializeField] private Material _falseConnected;

		public Transform ConnectionPoint => _connectionPoint;
		
		public void ForceDisconnect()
		{
			TryDisconnect();
		}

		public override bool TryConnectWith(IConnector connector)
		{
			bool isConnected = base.TryConnectWith(connector);
			
			if (isConnected)
			{
				SetIndicator(_connected);
			}
			
			return isConnected;
		}

		public override bool TryDisconnect()
		{
			bool isDisconnected = base.TryDisconnect();

			if (isDisconnected)
			{
				SetIndicator(_disconnected);
			}

			return isDisconnected;
		}
		
		public void SetIndicator(bool status)
		{	
			if (status)
			{
				SetIndicator(_trueConnected);
			}
			else
			{
				SetIndicator(_falseConnected);
			}
		}

		private void SetIndicator(Material material)
		{
			if (_indicator == null || material == null) return;
			_indicator.material = material;
		}
	}
}