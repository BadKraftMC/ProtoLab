using ForgeWorks.BroadStack.Workflow.Integration;

namespace ForgeWorks.ProtoLab;

public abstract partial class AppState
{
    internal const string LAUNCH_STATE = "launch";
    internal const string NULL_STATE = "null";

    public static AppState Empty { get; } = new NullState();

    [StateMachineState(NULL_STATE)]
    public class NullState : AppState
    {
        internal NullState() : this(NULL_STATE) { }
        public NullState(string name) : base(name) { }

        protected override bool OnEnter(out StateSubstate newSubState)
        {
            return OnExit(out newSubState);
        }

        protected override bool OnExecute(out StateSubstate newSubState)
        {
            //   should not be called
            throw new NotSupportedException();
        }

        protected override bool OnExit(out StateSubstate newSubState)
        {
            newSubState = StateSubstate.Exit;
            return true;
        }
    }
}
