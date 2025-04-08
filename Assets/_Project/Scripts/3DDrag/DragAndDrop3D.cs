using UnityEngine;

namespace JOPA.Utils
{
	public class DragAndDrop3D : MonoBehaviour
	{
		[SerializeField] private float _smooth = 1f;
		
		private static GameObject _currentlyDrag;
		private Vector3 mouseScreenPosition;

		public static GameObject CurrentlyDrag => _currentlyDrag;

		private Camera mainCamera => Camera.main;
		private Vector3 rawMouseScreenPosition => Input.mousePosition;

		private Vector3 GetObjectScreenPosition()
		{
			Vector3 objectScreenPoint = mainCamera.WorldToScreenPoint(transform.position);
			return objectScreenPoint;
		}
		
		private void OnMouseDown()
		{
			Vector3 objectScreenPosition = GetObjectScreenPosition();
			mouseScreenPosition = rawMouseScreenPosition - objectScreenPosition;

			_currentlyDrag = gameObject;
		}
		
		private void OnMouseDrag()
		{
			float currentSmooth = _smooth * Time.deltaTime;
			Vector3 newObjectScreenPosition = rawMouseScreenPosition - mouseScreenPosition;
			Vector3 newObjectWorldPosition = mainCamera.ScreenToWorldPoint(newObjectScreenPosition);
			transform.position = Vector3.Lerp(transform.position, newObjectWorldPosition, t: currentSmooth);
		}
		
		private void OnMouseUp()
		{
			_currentlyDrag = null;
		}
	}
}