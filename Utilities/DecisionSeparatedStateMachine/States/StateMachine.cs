using System.Collections.Generic;

namespace RH.Utilities.DecisionSeparatedStateMachine
{
    public class StateMachine
    {
        private readonly List<IState> _states;
        
        private IState _currentState;

        public StateMachine(IState firstState, params IState[] states)
        {
            _currentState = firstState;
            _states = new List<IState>();
            
            _states.Add(firstState);
            _states.AddRange(states);
        }

        public void SwitchState(IState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update()
        {
            if (_currentState.CanSwitchState(out IState state))
                SwitchState(state);
            else
                _currentState.Update();
        }
    }
}