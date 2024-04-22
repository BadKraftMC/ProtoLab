using ForgeWorks.ProtoLab;

using (var app = Domain.Initialize(new ProtoLab()))
{
    app.Run();
}

namespace ForgeWorks.ProtoLab
{
    internal class ProtoLab : IApplication
    {
        private static readonly Lazy<StateMachine> _statemachine;
        private bool IsReady { get; set; } = false;
        private IPlatform Platform { get; set; }
        private IWindow Window { get; set; }
        private StateMachine StateMachine => _statemachine.Value;

        internal bool IsDisposed { get; set; }

        public string Name { get; } = "ProtoLab";
        public AppState AppState => StateMachine.GetCurrent<AppState>();

        #region Constructors
        static ProtoLab()
        {
            _statemachine = new(() =>
            {
                var sm = new StateMachine(AppState.NULL_STATE);
                sm.Current.Enter();

                return sm;
            });
        }
        internal ProtoLab()
        {
            StateMachine.StateChanged += OnAppStateChanged;
        }
        #endregion

        internal void Run()
        {
            StateMachine.ChangeState(AppState.LAUNCH_STATE);

            if (IsReady)
            { Window.Run(); }

            Console.WriteLine($"Exiting ForgeWorks.ProtoLab [{(IsReady ? 0 : 1)}]... ");
        }

        void IApplication.Init()
        {
            //  called from Domain -- complete any domain-level initializations here
        }

        //  state is the previous state
        private void OnAppStateChanged(State state)
        {
            //  unsub events - not err-prone, so just do this
            state.SubstateTransition -= OnSubstateTransition;
            //  sub events of current state
            AppState.SubstateTransition += OnSubstateTransition;
            //  begin state
            AppState.Begin();
        }

        private void OnSubstateTransition(StateSubstate substate)
        {
            //  only one state right now so ...
            if (AppState is LaunchState launchState)
            {
                //  based on substate transition we have different things we want to call
                switch (substate)
                {
                    case StateSubstate.Enter:
                        Platform = Domain.Platform;
                        Console.WriteLine($"ForgeWorks.ProtoLab [{Platform.Name} ({Platform.Version})]");

                        break;
                    case StateSubstate.Execute:
                        Window = Domain.CreateWindow(new AppView(Name));

                        break;
                    case StateSubstate.Exit:
                        IsReady = true;

                        break;
                }

                return;
            }

            //  handle any other unexpected substate conditions
            switch (substate)
            {
                case StateSubstate.Unknown:

                    break;
                case StateSubstate.Idle:

                    break;
                case StateSubstate.Busy:

                    break;
                case StateSubstate.Error:

                    break;
                case StateSubstate.Invalid:

                    break;
            }
        }

        #region IDisposable
        public void Dispose()
        {
            IsDisposed = true;
        }
        #endregion
    }

}
