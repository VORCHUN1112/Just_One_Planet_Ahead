using System;
using JOPA.Modules.PortAndWire.Data;

namespace JOPA.Modules.PortAndWire.Services
{
	public class ConnectionHandler : IConnectionHandler
	{
		public static Action<Connection> OnConnected;
		
		public ConnectionHandler()
		{
			PortAndWireHandler.OnConnectionChecked += OnConnectionChecked;
		}
		
		~ConnectionHandler()
		{
			PortAndWireHandler.OnConnectionChecked -= OnConnectionChecked;
		}

		private static void OnConnectionChecked(Connection connection, bool status)
		{
			StandardPort port = connection.PortReference;
			port.SetIndicator(status);
		}

		public bool TryConnect(IConnector connector, IPort port)
		{
			if (connector is null || port is null) return false;
			
			bool isValidConnector = IsConnectable(connector);
			bool isValidPort = IsConnectable(port);
			bool isSubjectsReady = isValidConnector && isValidPort;

			if (!isSubjectsReady) return false;

			connector.TryConnectTo(port);
			port.TryConnectWith(connector);
			
			ConnectorInfo connectorInfo = (connector as StandardPortConnector).GetComponent<ConnectorInfo>();
			PortInfo portInfo = (port as StandardPort).GetComponent<PortInfo>();

			Connection connection = GetConnection(port, connector);
			OnConnected?.Invoke(connection);

			return true;
		}
		
		public bool TryConnect(IPort port, IConnector connector)
		{
			bool result = TryConnect(connector, port);
			return result;
		}
		
		public bool TryDisconnect(IConnector connector, IPort port)
		{
			bool isValidConnector = !IsConnectable(connector);
			bool isValidPort = !IsConnectable(port);
			bool isSubjectsReady = isValidConnector && isValidPort;

			if (!isSubjectsReady) return false;

			connector.TryDisconnect();
			port.TryDisconnect();
			
			return true;
		}
		
		public bool TryDisconnect(IPort port, IConnector connector)
		{
			bool result = TryDisconnect(connector, port);
			return result;
		}
		
		private bool IsConnectable(IPort port)
		{
			//if (port == null) return false;
			
			bool isValid = port.IsEmpty;
			return isValid;
		}

		private bool IsConnectable(IConnector connector)
		{
			//if (connector == null) return false;

			bool isValid = !connector.IsConnected;
			return isValid;
		}
				
		private Connection GetConnection(IPort port, IConnector connector)
		{
			ConnectorInfo connectorInfo = (connector as StandardPortConnector).GetComponent<ConnectorInfo>();
			PortInfo portInfo = (port as StandardPort).GetComponent<PortInfo>();

			Connection connection =
			new Connection(connectorInfo.Material, 
			connectorInfo.Connector, portInfo.Port, port as StandardPort);
			
			return connection;
		}
	}
}