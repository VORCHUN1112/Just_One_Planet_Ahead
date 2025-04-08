using UnityEngine;
using UnityEditor;
using Alchemy.Inspector;
using System;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new Connector", menuName = "JOPA/Port And Wire/New Connector", order = 100)]
	public class ConnectorData: Data<string>
	{
		[Button]
		public override void RenameAsset()
		{
			string newName = $"{Value}";
			
			SetAssetName(newName);
			base.RenameAsset();
		}
	}
}