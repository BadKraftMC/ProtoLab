namespace ForgeWorks.ProtoLab.Integration;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class StateActionAttribute : Attribute
{

    public string Name { get; }

    public StateActionAttribute(string name)
    {
        Name = name;
    }
}