using UnityEngine;

namespace JOPA.Modules.PortAndWire
{
    public abstract class Connector : MonoBehaviour, IConnector
	{
		private IPort _connectedTo;
		
		public IPort ConnectedTo => _connectedTo;
		public bool IsConnected => _connectedTo != null;

		public virtual bool TryConnectTo(IPort port)
		{
			if (IsConnected || port == null) return false;
			
			_connectedTo = port;
			return true;
		}

		public virtual bool TryDisconnect()
		{
			if (!IsConnected) return false;

			_connectedTo = null;
			return true;
		}
	}
}
