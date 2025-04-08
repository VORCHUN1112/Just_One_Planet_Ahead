using System;
using System.Collections.Generic;

namespace JOPA.StateMachine
{
	public partial class Machine
	{
		private StateNode _currentNode;
		private Dictionary<Type, StateNode> _nodes = new Dictionary<Type, StateNode>();
		private HashSet<ITransition> _anyTransition = new HashSet<ITransition>();

		private IState CurrentState => _currentNode.State;
		
		public void Update()
		{
			ITransition transition = GetTransition();
			
			if (transition != null)
			{
				ChangeState(transition.To);
			}

			CurrentState?.Update();
		}
		
		public void FixedUpdate()
		{
			CurrentState?.FixedUpdate();
		}
		
		public void SetState(IState state)
		{
			Type stateType = state.GetType();
			StateNode node = _nodes[stateType];

			_currentNode = node;
			CurrentState?.OnEnter();
		}
		
		public void ChangeState(IState state)
		{
			bool transitToItselt = state == CurrentState;
			if (transitToItselt) return;

			Type stateType = state.GetType();
			StateNode node = _nodes[stateType];

			IState previousState = CurrentState;
			IState nextState = node.State;

			previousState?.OnExit();
			nextState?.OnEnter();
			_currentNode = node;
		}
		
		public void AddTransition(IState from, IState to, IPredicate condition)
		{
			StateNode fromNode = GetOrAddNode(from);
			StateNode toNode = GetOrAddNode(to);

			fromNode.AddTransition(toNode.State, condition);
		}
		
		public void AddAnyTransition(IState to, IPredicate condition)
		{
			StateNode stateNode = GetOrAddNode(to);
			
			ITransition newTransition = new Transition(stateNode.State, condition);
			_anyTransition.Add(newTransition);
		}
		
		private ITransition GetTransition()
		{
			ITransition newTranstion  = null;
			
			foreach (ITransition transition in _anyTransition)
			{
				EvaluateTransition(transition);
			}
			
			foreach (ITransition transition in _currentNode.Transitions)
			{
				EvaluateTransition(transition);
			}
			
			return newTranstion;
			
			void EvaluateTransition(ITransition transition)
			{
				bool transitionApproved = transition.Condition.Evaluate();
				
				if (transitionApproved)
				{
					newTranstion = transition;
				}
			}
		}
		
		private StateNode GetOrAddNode(IState state)
		{
			Type stateType = state.GetType();
			StateNode node = _nodes.GetValueOrDefault(stateType);
			
			if (node == null)
			{
				node = new StateNode(state);
				_nodes.Add(stateType, node);
			}
			
			return node;
		}
	}
}
