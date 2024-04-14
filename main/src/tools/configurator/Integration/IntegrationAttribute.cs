namespace ForgeWorks.ProtoLab.Integration;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class IntegrationAttribute : Attribute
{

    public string Name { get; }

    public IntegrationAttribute(string name)
    {
        Name = name;
    }
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class StateActionAttribute : Attribute
{

    public string Name { get; }

    public StateActionAttribute(string name)
    {
        Name = name;
    }
}