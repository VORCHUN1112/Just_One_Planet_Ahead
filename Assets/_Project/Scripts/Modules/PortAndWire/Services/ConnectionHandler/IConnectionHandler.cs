namespace JOPA.Modules.PortAndWire.Services
{
	public interface IConnectionHandler
	{
		public bool TryConnect(IConnector connector, IPort port);
		public bool TryConnect(IPort port, IConnector connector);
		
		public bool TryDisconnect(IConnector connector, IPort port);
		public bool TryDisconnect(IPort port, IConnector connector);
	}
}