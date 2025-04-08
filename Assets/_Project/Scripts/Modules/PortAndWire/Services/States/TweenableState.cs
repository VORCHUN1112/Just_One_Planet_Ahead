using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Events;
using Alchemy.Inspector;
using JOPA.StateMachine;

namespace JOPA.Modules.PortAndWire.States
{
	[Serializable]
	public abstract class TweenableState : State
	{
		[BoxGroup("Кастомное имя")]
		[SerializeField] private string _name;

		[BoxGroup("Настройки анимации")]
		[SerializeField] protected TweenSettings _tweenSettings;
		private Tween _tween;
		
		public Tween Tween => _tween;

		[BoxGroup("События")]
		[Space(10)]
		public UnityEvent OnEntered;

		[BoxGroup("События")]
		[Space(10)]
		public UnityEvent OnExited;

		public void Initialize(Tween tween)
		{
			_tween = tween;
			_tween.Pause();
		}

		public override void OnEnter()
		{
			_tween.Play();
			OnEntered?.Invoke();
		}

		public override void OnExit()
		{
			_tween.Kill();
			OnExited?.Invoke();
		}
	}
}