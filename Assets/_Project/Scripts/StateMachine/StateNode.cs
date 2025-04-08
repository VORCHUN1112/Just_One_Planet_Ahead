using System.Collections.Generic;

namespace JOPA.StateMachine
{
    public partial class Machine
	{
        public class StateNode
		{
			private readonly IState _state;
			private HashSet<ITransition> _transitions;

			public IState State => _state;
			public HashSet<ITransition> Transitions => _transitions;
			
			public StateNode(IState state)
			{
				_state = state;
				_transitions = new HashSet<ITransition>();
			}
			
			public void AddTransition(IState to, IPredicate condition)
			{
				Transition newTransition = new Transition(to, condition);
				_transitions.Add(newTransition);
			}
		}
	}
}
