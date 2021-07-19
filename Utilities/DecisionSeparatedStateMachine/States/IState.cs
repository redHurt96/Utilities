namespace RH.Utilities.DecisionSeparatedStateMachine
{
    public interface IState
    {
        bool CanSwitchState(out IState transition);
        void Enter();
        void Update();
        void Exit();
    }
}
