using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.States
{
	[Serializable]
	public class Preconnected : TweenableState
	{
		public override void OnEnter()
		{
			Initialize();
			base.OnEnter();

			//Debug.Log("Preconnected");
		}

		public void Initialize()
		{
			Transform animateable = _tweenSettings.Animateable;
			Vector3 endValue = new Vector3(270, 0, 0);
			float duration = _tweenSettings.Duration;
			Ease ease = _tweenSettings.Ease;

			Tween tween = animateable
			.DOLocalRotate(endValue, duration: duration)
			.SetEase(ease: ease);

			Initialize(tween);
		}
	}
}