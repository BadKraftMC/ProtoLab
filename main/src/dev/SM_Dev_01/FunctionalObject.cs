namespace SM_Dev_01;

public class FunctionalObject
{
    private readonly IEnumerable<FunctionalState> STATES = new FunctionalState[] {
            FunctionalState.Idle,
            FunctionalState.Configure,
            FunctionalState.Ready,
            FunctionalState.Busy,
            FunctionalState.Done,
        };

    private IEnumerator<FunctionalState> Change { get; set; }

    public FunctionalState State { get; set; }

    public FunctionalObject()
    {
        Change = STATES.GetEnumerator();
        State = Change.Current;
    }

    public void ChangeState()
    {

    }
}

public enum FunctionalState
{
    Fault = -1,
    Unknown = 0,
    Idle = 1,
    Configure = 2,
    Ready = 3,
    Busy = 4,
    Done = 5,
}
