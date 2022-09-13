public abstract class BaseState
{
    public Enemy enemy; // Instance of enemy class
    public StateMachine stateMachine; // Instance of statemachine class

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
