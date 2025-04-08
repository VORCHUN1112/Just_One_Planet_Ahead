namespace JOPA.StateMachine
{
    public class Transition : ITransition
	{
		private readonly IState _to;
		private readonly IPredicate _condition;
		
		public IState To => _to;
		public IPredicate Condition => _condition;
		
		public Transition(IState to, IPredicate condition)
		{
			_to = to;
			_condition = condition;
		}
	}
}