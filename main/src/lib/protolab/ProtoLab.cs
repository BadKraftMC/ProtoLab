
using System.Runtime.InteropServices;

using ForgeWorks.ProtoLab;

using (var app = new ProtoLab())
{
    app.Run();
}

namespace ForgeWorks.ProtoLab
{
    internal partial class ProtoLab : IDisposable
    {
        private IPlatform Platform { get; }
        private Window _Window { get; }

        internal bool IsDisposed { get; set; }

        internal ProtoLab()
        {
            Platform = GetPlatform();
            Platform.Initialize();
            _Window = new(new AppView());

            Console.WriteLine($"ForgeWorks.ProtoLab [{Platform.Name} ({Platform.Version})]");
        }

        internal void Run()
        {
            _Window.Run();
            Console.WriteLine("Exiting ForgeWorks.ProtoLab ... ");
        }

        private static IPlatform GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Internal.Platform.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Internal.Platform.Linux;
            }

            return Internal.Platform.None;
        }

        #region IDisposable
        public void Dispose()
        {
            Platform.Dispose();
            IsDisposed = true;
        }
        #endregion
    }

}
