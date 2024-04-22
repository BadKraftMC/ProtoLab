using ForgeWorks.BroadStack.Workflow.Integration;

namespace ForgeWorks.ProtoLab;

[StateMachineState(LAUNCH_STATE)]
public class LaunchState : AppState
{
    public LaunchState(string name) : base(name) { }

    protected override bool OnEnter(out StateSubstate newSubState)
    {
        //  load any integration ...

        newSubState = StateSubstate.Enter;
        return true;
    }

    protected override bool OnExecute(out StateSubstate newSubState)
    {
        newSubState = StateSubstate.Execute;
        return true;
    }

    protected override bool OnExit(out StateSubstate newSubState)
    {
        newSubState = StateSubstate.Exit;
        return true;
    }
}
