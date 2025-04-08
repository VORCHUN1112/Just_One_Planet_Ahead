namespace JOPA.Modules.PortAndWire
{
	public interface IConnector
	{
		public IPort ConnectedTo { get; }
		public bool IsConnected { get; }

		public bool TryConnectTo(IPort connector);
		public bool TryDisconnect();
	}
}