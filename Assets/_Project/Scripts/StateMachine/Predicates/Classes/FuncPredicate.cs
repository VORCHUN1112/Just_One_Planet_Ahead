using System;

namespace JOPA.StateMachine
{
    public class FuncPredicate : IPredicate
	{
		private readonly Func<bool> _func;
		
		private Func<bool> Func => _func;
		
		public FuncPredicate(Func<bool> func)
		{
			_func = func;
		}
		
		public bool Evaluate()
		{
			bool evaluation = _func.Invoke();
			return evaluation;
		}
	}
}