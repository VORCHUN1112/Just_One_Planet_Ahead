using System;
using UnityEngine;

namespace JOPA.Modules.PortAndWire
{
	[Serializable]
	public abstract class Port : MonoBehaviour, IPort
	{
		private IConnector _connected;

		public IConnector Connected => _connected;
		public bool IsEmpty => _connected == null;

		public virtual bool TryConnectWith(IConnector connector)
		{
			if (!IsEmpty || connector == null) return false;

			_connected = connector;
			return true;
		}

		public virtual bool TryDisconnect()
		{
			if (IsEmpty) return false;
			
			_connected = null;
			return true;
		}
	}
}