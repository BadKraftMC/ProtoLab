using ForgeWorks.ProtoLab;

using (var app = Domain.Initialize(new ProtoLab()))
{
    app.Run();
}

namespace ForgeWorks.ProtoLab
{
    internal class ProtoLab : IApplication
    {
        private IPlatform Platform { get; }
        private IWindow Window { get; set; }

        internal bool IsDisposed { get; set; }

        public string Name { get; } = "ProtoLab";

        internal ProtoLab()
        {
            Platform = Domain.Platform;

            Console.WriteLine($"ForgeWorks.ProtoLab [{Platform.Name} ({Platform.Version})]");
        }

        internal void Run()
        {
            Window.Run();
            Console.WriteLine("Exiting ForgeWorks.ProtoLab ... ");
        }

        void IApplication.Init()
        {
            //  called from Domain -- complete any domain-level initializations here
            Window = Domain.CreateWindow(new AppView(Name));
        }

        #region IDisposable
        public void Dispose()
        {
            IsDisposed = true;
        }
        #endregion
    }

}
