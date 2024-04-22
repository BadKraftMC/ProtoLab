namespace ForgeWorks.ProtoLab;

public abstract partial class AppState : State
{
    private static readonly List<StateSubstate> SUBSTATE_CYCLES = new() {
        StateSubstate.Enter, StateSubstate.Execute, StateSubstate.Exit
    };

    protected AppState(string name) : base(name) { }

    /// <summary>
    /// Begins cycling transitions - Enter, Execute, Exit
    /// </summary>
    internal void Begin()
    {
        IEnumerator<StateSubstate> cycle = SUBSTATE_CYCLES.GetEnumerator();

        while (cycle.MoveNext())
        {
            Transition(cycle.Current);
        }
    }
}
