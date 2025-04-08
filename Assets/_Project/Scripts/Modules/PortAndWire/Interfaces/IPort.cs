namespace JOPA.Modules.PortAndWire
{
	public interface IPort
	{
		public IConnector Connected { get; }
		public bool IsEmpty { get; }

		public bool TryConnectWith(IConnector connector);
		public bool TryDisconnect();
	}
}