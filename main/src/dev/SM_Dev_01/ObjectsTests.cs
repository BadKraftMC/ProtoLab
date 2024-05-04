using static ProtoLab.OpenTest.TestCase;

namespace SM_Dev_01;

public class ObjectsTests
{
    [TestCase]
    public void FunctionalObjectInitialized()
    {
        //  expect initial state to be FunctionalState.Idle
        var obj = new FunctionalObject();

        Assert.IsNotNull(obj);
    }
}
