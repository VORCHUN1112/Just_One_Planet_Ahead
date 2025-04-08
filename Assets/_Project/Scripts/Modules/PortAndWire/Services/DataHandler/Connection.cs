using UnityEngine;
using System;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[Serializable]
	[HorizontalGroup]
	public class Connection
	{
		[BoxGroup("Данные")]
		[SerializeField] private WireMaterialData _wireMaterial;

		[BoxGroup("Данные")]
		[SerializeField] private ConnectorData _connector;

		[BoxGroup("Данные")]
		[SerializeField] private PortData _port;

		[BoxGroup("Данные/Ссылки")]
		[SerializeField] private StandardPort _portReference;

        public Connection(WireMaterialData wireMaterial, ConnectorData connector, PortData port, StandardPort portReference)
        {
            _wireMaterial = wireMaterial;
            _connector = connector;
            _port = port;
            _portReference = portReference;
        }

        public WireMaterialData WireMaterial => _wireMaterial; 
		public ConnectorData Connector => _connector; 
		public PortData Port => _port;
        public StandardPort PortReference => _portReference;
    }
}
