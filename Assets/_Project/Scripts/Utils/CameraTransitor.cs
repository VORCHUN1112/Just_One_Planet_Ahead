using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTransitor : MonoBehaviour
{
	[Header("Input Settings")]
	[SerializeField] private KeyCode _previousPoint;
	[SerializeField] private KeyCode _nextPoint;

	[Header("Animation Setting")]
	[SerializeField] private Ease _moveEase;
	[SerializeField] private float _moveDuration;
	
	[Space(5)]
	[SerializeField] private Ease _rotationEase;
	[SerializeField] private float _rotationDuration;

	[Header("Points")]
	[SerializeField] private List<Transform> _points = new List<Transform>();
	private Transform _currentPoint;
	
	private void Start()
	{
		Transform firstPoint = _points.First();
		Transit(firstPoint);
	}
	
	private void Update()
	{
		ReadInputs();
	}
	
	private void ReadInputs()
	{
		bool previousPressed = Input.GetKeyDown(_previousPoint);
		if (previousPressed)
		{
			GoGreviuous();
			return;
		}

		bool nextPressed = Input.GetKeyDown(_nextPoint);
		if (nextPressed)
		{
			GoNext();
			return;
		}
	}
	
	private void GoGreviuous()
	{
		LinkedList<Transform> points = new LinkedList<Transform>(_points);
		LinkedListNode<Transform> previousNode = points.Find(_currentPoint).Previous;
		
		Transform previous;
		if (previousNode != null)
		{
			previous = previousNode.Value;
		}
		else
		{
			previous = points.Last();
		}


		Transit(previous);
	}
	
	private void GoNext()
	{
		LinkedList<Transform> points = new LinkedList<Transform>(_points);
		LinkedListNode<Transform> nextNode = points.Find(_currentPoint).Next;
		
		Transform next;
		if (nextNode != null)
		{
			next = nextNode.Value;
		}
		else
		{
			next = points.First();
		}
		
		Transit(next);
	}
	
	private void Transit(Transform target)
	{
		Vector3 targetPosition = target.position;
		Quaternion targetRotation = target.rotation;

		_currentPoint = target;
		transform.DOMove(targetPosition, _moveDuration).SetEase(_moveEase);
		transform.DORotateQuaternion(targetRotation, _rotationDuration).SetEase(_rotationEase);
	}
}