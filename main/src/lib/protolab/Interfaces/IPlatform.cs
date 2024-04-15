namespace ForgeWorks.ProtoLab;

public interface IPlatform : IDisposable
{
    string Name { get; }
    Version Version { get; }

    void Initialize();
}
