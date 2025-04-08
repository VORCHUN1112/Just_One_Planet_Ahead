using System;

namespace JOPA.StateMachine
{
	[Serializable]
	public abstract class State : IState
	{
		public virtual void OnEnter()
		{
			//ничего
		}
		
		public virtual void Update()
		{
			//ничего
		}
		
		public virtual void FixedUpdate()
		{
			//ничего
		}

		public virtual void OnExit()
		{
			//ничего
		}
	}
}