using System.Collections.Generic;

namespace RH.Utilities.DecisionSeparatedStateMachine
{
    public abstract class BaseState : IState
    {
        private readonly Dictionary<Decision, IState> _statesSwitchers;

        public BaseState(params KeyValuePair<Decision, IState>[] statesSwitchers)
        {
            _statesSwitchers = new Dictionary<Decision, IState>();

            foreach (var switcher in statesSwitchers)
                _statesSwitchers.Add(switcher.Key, switcher.Value);
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public bool CanSwitchState(out IState state)
        {
            foreach (KeyValuePair<Decision, IState> switcher in _statesSwitchers)
            {
                if (switcher.Key.CanMade())
                {
                    state = switcher.Value;
                    return true;
                }
            }

            state = null;
            return false;
        }
    }
}