using System;
using UnityEngine;
using DG.Tweening;
using Alchemy.Inspector;
using JOPA.Modules.PortAndWire;
using JOPA.Modules.PortAndWire.Services;

namespace JOPA.Modules.PortAndWire.States
{
	[Serializable]
	public class Connected : TweenableState
	{
		private IPort _port;
		private IConnector _connector;

		public override void OnEnter()
		{
			Initialize();
			base.OnEnter();

			//Debug.Log("Connected");
		}

		public void PushInfo(IPort port, IConnector connector)
		{
			_port = port as StandardPort;
			_connector = connector as StandardPortConnector;
		}
		
		public void Initialize()
		{
			Transform animateable = _tweenSettings.Animateable;
			Vector3 endValue = (_port as StandardPort).ConnectionPoint.position;
			float duration = _tweenSettings.Duration;
			Ease ease = _tweenSettings.Ease;

			Tween tween = animateable
			.DOMove(endValue, duration: duration)
			.SetEase(ease)
			.OnComplete(() => PerformConnection());

			Initialize(tween);
		}
		
		private void PerformConnection()
		{
			IConnectionHandler handler = new ConnectionHandler();
			handler.TryConnect(_connector, _port);
		}
	}
	
}