using UnityEngine;
using UnityEditor;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new Ship", menuName = "JOPA/Port And Wire/New Ship", order = 100)]
	public class ShipSerialData : Data<string>
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