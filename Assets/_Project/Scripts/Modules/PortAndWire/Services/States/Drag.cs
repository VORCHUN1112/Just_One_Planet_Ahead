using System;
using DG.Tweening;
using UnityEngine;

namespace JOPA.Modules.PortAndWire.States
{
	[Serializable]
	public class Drag : TweenableState
	{
		private bool _tweenCompleted = false;

		public override void OnEnter()
		{
			Initialize();
			base.OnEnter();
		}

		public override void Update()
		{
			if (!_tweenCompleted) return;

			Transform animateable = _tweenSettings.Animateable;
			Transform target = _tweenSettings.Target;
			animateable.LookAt(target, Vector3.forward);
		}

		public void Initialize()
		{
			Transform animateable = _tweenSettings.Animateable;
			Vector3 endValue = _tweenSettings.Target.position;
			float duration = _tweenSettings.Duration;
			Ease ease = _tweenSettings.Ease;

			AxisConstraint constraint = AxisConstraint.None;

			_tweenCompleted = false;
			
			Tween tween = animateable
			.DODynamicLookAt(endValue, duration, constraint, Vector3.forward)
			.SetEase(ease)
			.OnComplete(() => _tweenCompleted = true);

			Initialize(tween);
		}
	}
}