using UnityEngine;
using UnityEditor;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new Port", menuName = "JOPA/Port And Wire/New Port", order = 100)]
	public class PortData : Data<string>
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