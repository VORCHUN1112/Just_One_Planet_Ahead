using System;
using DG.Tweening;
using JOPA.Modules.PortAndWire.Services;
using JOPA.Modules.PortAndWire.States;
using JOPA.StateMachine;
using UnityEngine;

namespace JOPA.Modules.PortAndWire
{
	public class PlugExecutor : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Connector _connector;
		[Header("States")]
		[SerializeReference] [SerializeField] private IState[] _states;

		[Header("Flags")]
		[SerializeField] private bool _selected = false;
		[SerializeField] private bool _hold = false;
		[SerializeField] private bool _inPortArea = false;
		private Machine _machine;
		private IPort _lastHovered;
		
		private bool InEmptyPortArea
		{
			get
			{
				if (_lastHovered == null) return false;

				bool isPortEmpty = _lastHovered.IsEmpty;
				return isPortEmpty;
			}
		}

		private void Start()
		{
			InitializeMachine();
			InitializeStates();
			//1) Код ревью.
			//2) Опредеить работу с репосом, соглашение имен, архитектура (всей вселенной).
			//3) Регулярные созвоны под чай.
		}
		
		private void InitializeStates()
		{
			TweenableState intoPlug = _states[0] as TweenableState;
			TweenableState readyForDrag = _states[1] as TweenableState;
			TweenableState drag = _states[2] as TweenableState;
			TweenableState readyForConnection = _states[3] as TweenableState;
			TweenableState rotateToPlayer = _states[4] as TweenableState;
			TweenableState connected = _states[5] as TweenableState;

			At(intoPlug, readyForDrag, GetCondition(() => _selected));
			At(rotateToPlayer, intoPlug, GetCondition(() => IsCompleted(rotateToPlayer)));
			At(readyForDrag, rotateToPlayer, GetCondition(() => !_selected && IsCompleted(readyForDrag)));
			At(readyForDrag, drag, GetCondition(() => _hold));
			At(drag, readyForDrag, GetCondition(() => !_hold));
			At(drag, readyForConnection, GetCondition(() => InEmptyPortArea));
			At(readyForConnection, drag, GetCondition(() => !_inPortArea));
			At(readyForConnection, connected, GetCondition(() => !_hold && IsCompleted(readyForConnection) && InEmptyPortArea));
			At(connected, readyForConnection, GetCondition(() => _hold));

			connected.OnExited.AddListener(TryDisconnect);

			_machine.SetState(intoPlug);
		}
		
		private void InitializeMachine()
		{
			_machine = new Machine();
		}

		private FuncPredicate GetCondition(Func<bool> func)
		{
			return new FuncPredicate(func);
		}
		
		private bool IsCompleted(TweenableState state)
		{
			return !state.Tween.IsActive();
		}
		
		private void At(IState from, IState to, IPredicate condition)
		{
			_machine.AddTransition(from, to, condition);
		}
		
		private void Any(IState to, IPredicate predicate)
		{
			_machine.AddAnyTransition(to, predicate);
		}
		
		private void Update()
		{
			_machine?.Update();
		}
		
		private void FixedUpdate()
		{
			_machine?.FixedUpdate();
		}
		
		public void Select()
		{
			_selected = true;
		}
		
		public void Deselect()
		{
			_selected = false;
		}

		public void Pressed()
		{
			_hold = true;
		}

		public void Hold()
		{
			Debug.Log("Hold");
		}

		public void Released()
		{
			_hold = false;
		}

		public void PortAreaEntered(IPort port)
		{
			_inPortArea = true;
			_lastHovered = port;
			
			Connected connected = _states[5] as Connected;
			connected.PushInfo(_lastHovered, _connector);
		}
		
		public void PortAreaStay()
		{
			
		}
		
		public void PortAreaExited(IPort port)
		{
			_inPortArea = false;
			_lastHovered = null;

			Connected connected = _states[5] as Connected;
			connected.PushInfo(null, null);
		}
		
		private void TryDisconnect()
		{
			IPort port = _connector.ConnectedTo;
			if (port == null) return;

			IConnectionHandler handler = new ConnectionHandler();
			handler.TryDisconnect(port, _connector);
		}
    
}
}