using UnityEngine;
using UnityEditor;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new Battery", menuName = "JOPA/Port And Wire/New Battery", order = 100)]
	public class BatteryData: Data<int>
	{
		[Button]
		public override void RenameAsset()
		{
			string newName = $"{Value}%";
			SetAssetName(newName);
			base.RenameAsset();
		}
	}
}