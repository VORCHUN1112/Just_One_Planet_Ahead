using UnityEngine;
using UnityEngine.Events;

namespace JOPA.Utils
{
	public class Selectable3D : MonoBehaviour
	{
		private bool _selected = false;
		
		public bool Selected => _selected;
		
		[Header("Events")]
		[Space (5)]
		public UnityEvent OnSelected;
		public UnityEvent OnDeselected;
		public UnityEvent OnMousePressed;
		public UnityEvent OnMouseHold;
		public UnityEvent OnMouseReleased;
		
		public void Select()
		{
			if (_selected) return;
			
			_selected = true;
			OnSelected?.Invoke();
		}
		
		public void Deselect()
		{
			if (!_selected) return;
			
			_selected = false;
			OnDeselected?.Invoke();
		}
		
		private void OnMouseEnter()
		{
			Select();
		}
		
		private void OnMouseExit()
		{
			Deselect();
		}
		
		private void OnMouseDown()
		{
			OnMousePressed?.Invoke();
		}
		
		private void OnMouseDrag()
		{
			OnMouseHold?.Invoke();
		}
		
		private void OnMouseUp()
		{
			OnMouseReleased.Invoke();
		}
	}
}