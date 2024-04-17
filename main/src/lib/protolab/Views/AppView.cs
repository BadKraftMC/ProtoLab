using System.ComponentModel;

namespace ForgeWorks.ProtoLab;

public class AppView : WindowView
{
    internal AppView(string name)
    {
        ClientSize = (1200, 850);
        WindowState = WindowState.Normal;
        WindowBorder = WindowBorder.Resizable;
        //  TODO: see OnLoad
        IsVisible = true;       // false
        Title = $"ForgeWorks {name}";
    }

    public override void OnLoad()
    {
        //  TODO: add property change notification for the Window
        // IsVisible = true;
    }
    public override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }
    public override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
    }
}
