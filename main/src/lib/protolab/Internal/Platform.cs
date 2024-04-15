using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ForgeWorks.ProtoLab.Internal;

internal abstract class Platform : IPlatform
{
    internal static IPlatform Windows = new WindowsPlatform();
    internal static IPlatform Linux = new LinuxPlatform();
    internal static IPlatform None = new NoOpPlatform();

    public string Name { get; }
    public virtual Version Version { get; } = Environment.OSVersion.Version;

    protected Platform(string name)
    { Name = name; }

    public abstract void Initialize();
    public abstract void Dispose();

    internal class NoOpPlatform : Platform
    {
        public override Version Version { get; } = new(0, 0, 0);

        internal NoOpPlatform() : base("NoOp") { }

        public override void Initialize()
        { /* Not Implemented" */ }

        public override void Dispose()
        { /* Not Implemented" */ }
    }

    internal class WindowsPlatform : Platform
    {
        [DllImport("kernel32")]
        static extern int AllocConsole();
        [DllImport("kernel32")]
        static extern void FreeConsole();

        internal WindowsPlatform() : base("Windows") { }

        public override void Initialize()
        {
            AllocConsole();
        }

        public override void Dispose()
        {
            FreeConsole();
        }
    }

    internal class LinuxPlatform : Platform
    {
        internal LinuxPlatform() : base("Linux") { }

        public override void Initialize()
        {

        }

        #region IDisposable
        public override void Dispose()
        {

        }
        #endregion
    }
}
