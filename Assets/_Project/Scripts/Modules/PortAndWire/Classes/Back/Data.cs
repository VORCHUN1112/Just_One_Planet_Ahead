using UnityEngine;
using UnityEditor;

namespace JOPA.Modules.PortAndWire.Data
{
	public abstract class Data<T> : ScriptableObject
	{
		[Header("Settings")]
		[SerializeField] private T _value;
		private string _assetName = string.Empty;
		
		public T Value => _value;
		
		public virtual void RenameAsset()
		{
			string path = AssetDatabase.GetAssetPath(assetObject: this);
			string result = AssetDatabase.RenameAsset(path, _assetName);

			bool success = result == string.Empty;
			if (success) return;
			
			Debug.Log(result);
		}
		
		protected virtual void SetAssetName(string name)
		{
			_assetName = name;
		}
	}
}