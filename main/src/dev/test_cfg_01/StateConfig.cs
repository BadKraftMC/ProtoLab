using ForgeWorks.ProtoLab.Integration;

namespace ProtoLab.Sample.StateConfigurator._01;

[Integration("sample_01")]
public class StateConfig
{
    public StateConfiguration state_config { get; set; } = new()
    {
        on_state = "on_loaded",
        execute = "write_line"
    };

    [StateAction("write_line")]
    private void WriteLine()
    {
        Console.WriteLine($"{nameof(StateConfig)}.{nameof(WriteLine)}");
    }
}
