using System;
using UnityEngine;
using DG.Tweening;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.States
{
	[Serializable]
	[HorizontalGroup]
	public class TweenSettings
	{
		[Group]
		[SerializeField] private float _duration = 1f;
		
		[Group]
		[SerializeField] private Ease _ease = Ease.Linear;
		
		[Group]
		[SerializeField] private Transform _animateable;

		[Group]
		[SerializeField] private Transform target;
		
		public float Duration => _duration;
		public Ease Ease => _ease;
		public Transform Animateable => _animateable; 
		public Transform Target => target;
	}
}