using UnityEngine;
using UnityEditor;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new Color", menuName = "JOPA/Port And Wire/New Color", order = 100)]
	public class WireMaterialData : Data<Material>
	{
		[Header("Additional")]
		[SerializeField] private bool _customName = false;
		
		[ShowIf(nameof(_customName))]
		[SerializeField] private string _customAssetName;
		
		[Button]
		public override void RenameAsset()
		{
			string newName;

			if (_customName)
			{
				newName = $"{_customAssetName}";
			}
			else
			{
				newName = $"{Value.name}";
			}

			SetAssetName(newName);
			base.RenameAsset();
		}
	}
}