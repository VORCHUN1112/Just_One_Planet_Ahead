using UnityEngine;

namespace JOPA.Utils
{
	public class SelectableGroup3D : MonoBehaviour
	{
		[SerializeField] private Selectable3D[] _selectables = new Selectable3D[0];

		private void Start()
		{
			SubscribeEvents();
		}
		
		private void Select(Selectable3D selectable)
		{
			bool selected = selectable.Selected;
			if (selected) return;

			selectable.Select();		
		}
		
		private void Deselect(Selectable3D selectable)
		{
			bool deselected = !selectable.Selected;
			if (deselected) return;

			selectable.Deselect();
		}
		
		private void SelectAll()
		{
			foreach(Selectable3D selectable in _selectables)
			{
				Select(selectable);
			}
		}
		
		private void DeselectAll()
		{
			foreach(Selectable3D selectable in _selectables)
			{
				Deselect(selectable);
			}
		}

		private void SubscribeEvents()
		{
			foreach (Selectable3D selectable in _selectables)
			{
				selectable.OnSelected.AddListener(SelectAll);
				selectable.OnDeselected.AddListener(DeselectAll);
			}
		}
	}	
}