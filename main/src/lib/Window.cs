using System.ComponentModel;

namespace ForgeWorks.ProtoLab;

internal partial class ProtoLab
{
    private class Window : GameWindow, RailThorn.Windows.IGraphicsContext, IInputContext
    {
        private IView View { get; set; }

        public IInputContext Input => throw new NotImplementedException();

        #region Constructor
        public Window(IView view) : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            ClientSize = view.ClientSize,
            WindowState = view.WindowState,
            WindowBorder = view.WindowBorder,
            StartVisible = view.IsVisible,
            Title = view.Title
        })
        {
            SetView(view);
        }
        #endregion

        #region View overrides
        protected override void OnClosing(CancelEventArgs args)
        {
            View.OnClosing(args);
        }
        protected override void OnFileDrop(FileDropEventArgs args)
        {
            View.OnFileDrop(args);
        }
        protected override void OnFocusedChanged(FocusedChangedEventArgs args)
        {
            View.OnFocusChanged(args);
        }
        protected override void OnFramebufferResize(FramebufferResizeEventArgs args)
        {
            View.OnFramebufferResize(args);
        }
        protected override void OnJoystickConnected(JoystickEventArgs args)
        {
            View.OnJoystickConnected(args);
        }
        protected override void OnKeyDown(KeyboardKeyEventArgs args)
        {
            View.OnKeyDown(args);
        }
        protected override void OnKeyUp(KeyboardKeyEventArgs args)
        {
            View.OnKeyUp(args);
        }
        protected override void OnLoad()
        {
            View.Init(this);
            View.OnLoad();
        }
        protected override void OnMaximized(MaximizedEventArgs args)
        {
            View.OnMaximized(args);
        }
        protected override void OnMinimized(MinimizedEventArgs args)
        {
            View.OnMinimized(args);
        }
        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            View.OnMouseDown(args);
        }
        protected override void OnMouseEnter()
        {
            View.OnMouseEnter();
        }
        protected override void OnMouseLeave()
        {
            View.OnMouseLeave();
        }
        protected override void OnMouseMove(MouseMoveEventArgs args)
        {
            View.OnMouseMove(args);
        }
        protected override void OnMouseUp(MouseButtonEventArgs args)
        {
            View.OnMouseUp(args);
        }
        protected override void OnMouseWheel(MouseWheelEventArgs args)
        {
            View.OnMouseWheel(args);
        }
        protected override void OnMove(WindowPositionEventArgs args)
        {
            View.OnMove(args);
        }
        protected override void OnRefresh()
        {
            View.OnRefresh();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            View.OnRenderFrame(args);
        }
        protected override void OnResize(ResizeEventArgs args)
        {
            View.OnResize(args);
        }
        protected override void OnTextInput(TextInputEventArgs args)
        {
            View.OnTextInput(args);
        }
        protected override void OnUnload()
        {
            View.OnUnload();
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            View.OnUpdateFrame(args);
        }
        #endregion

        internal void SetView(IView view)
        {
            View = view ?? View;
        }
        internal void ChangeView(IView view)
        {
            //  if view is null, keep the same view
            SetView(view);

            if (view != null)
            {
                ClientSize = view.ClientSize;
                WindowBorder = view.WindowBorder;
                WindowState = view.WindowState;
                IsVisible = view.IsVisible;
            }
        }

        public KeyboardState GetKeyboardState()
        {
            return KeyboardState;
        }

        public MouseState GetMouseState()
        {
            return MouseState;
        }
    }

}
