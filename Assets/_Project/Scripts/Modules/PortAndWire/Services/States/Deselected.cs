using System;
using UnityEngine;
using DG.Tweening;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.States
{
    [Serializable]
	public class Deselected : TweenableState
	{
		public override void OnEnter()
		{
			Initialize();
			base.OnEnter();

			//Debug.Log("Deselected");
		}

		public void Initialize()
		{
			Transform animateable = _tweenSettings.Animateable;
			Vector3 endValue = _tweenSettings.Target.position;
			float duration = _tweenSettings.Duration;
			Ease ease = _tweenSettings.Ease;

			Tween tween = animateable
			.DOMove(endValue, duration: duration)
			.SetEase(ease);

			Initialize(tween);
		}
	}
}