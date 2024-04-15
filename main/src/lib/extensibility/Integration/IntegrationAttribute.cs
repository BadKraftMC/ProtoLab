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
