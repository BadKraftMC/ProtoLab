using static ProtoLab.OpenTest.TestSet;

public class ObjectNullTests
{
    private List<object> objList;

    [TestCase(ignore: false)]
    public void ObjectIsNull()
    {
        objList = null;
        Assert.IsNull(objList);
    }

    [TestCase]
    public void ObjectIsNotNull()
    {
        objList = new();
        Assert.IsNotNull(objList);
    }

    [TestCase]
    public void MultiAssertsWithLogs()
    {
        objList = new();

        //  produces a null exception
        //  Log.Write("Log entry prior to test assertion");
        /* **
            TODO: add log feature to write log entries before a test run object is created
        ** */

        Assert.IsTrue(objList.Count == 0);
        Log.Write($"objList count: ({objList.Count})");
        Log.Write("Log entries follow test assertions");

        objList.Add(new());
        Assert.AreEqual(1, objList.Count);
        Log.Write($"objList count: ({objList.Count})");
    }
}
