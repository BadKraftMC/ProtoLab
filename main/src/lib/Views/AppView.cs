using System.ComponentModel;

namespace ForgeWorks.ProtoLab;

public class AppView : WindowView
{
    //  TODO: IWindowContext (combine the following interfaces into a single context interface)
    internal AppView()
    {
        ClientSize = (1200, 850);
        WindowState = WindowState.Normal;
        WindowBorder = WindowBorder.Resizable;
        IsVisible = true;
        Title = "ForgeWorks ProtoLab";
    }

    public override void OnLoad()
    {

    }
    public override void OnUpdateFrame(FrameEventArgs args)
    {

    }
    public override void OnRenderFrame(FrameEventArgs args)
    {
        SwapBuffers();
    }
}
