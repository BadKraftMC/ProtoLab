using static ProtoLab.OpenTest.TestSet;

public class ObjectTests
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

        Assert.Log("Log entry prior to test assertion");
        Assert.IsTrue(objList.Count == 0);
        Assert.Log($"objList count: ({objList.Count})");

        objList.Add(new());

        Assert.AreEqual(1, objList.Count);
        Assert.Log($"objList count: ({objList.Count})");
    }

    [TestCase]
    public void AssertWithMessage()
    {
        objList = new() { new() };

        Assert.IsTrue(objList.Count == 1, $"list count: {objList.Count}");
    }

    [TestCase]
    public void VerboseAssertion()
    {
        objList = new() { new() };

        AssertVerbose.AreEqual(1, objList.Count, "Verbose assertion test case");
        AssertVerbose.AreNotEqual(objList.Count, 2);
        AssertVerbose.AreEqual(2, objList.Count, $"{nameof(objList)}.Count ({objList.Count})");
    }

    [TestCase]
    public void AssertsFailMessages()
    {
        objList = null;
        Assert.IsNotNull(objList);

        objList = new();
        Assert.IsNull(objList);

        objList.Add(new());
        Assert.IsFalse(objList.Any());
        Assert.AreEqual(0, objList.Count);
        Assert.AreNotEqual(1, objList.Count);
    }

    [TestCase]
    public void AssertIs()
    {
        objList = new();

        Assert.Is<List<object>>(objList);
        Assert.Is<List<char>>(objList);
    }

    [TestCase]
    public void AssertIsNot()
    {
        objList = new();

        Assert.IsNot<List<char>>(objList);
        Assert.IsNot<List<object>>(objList);
    }

    [TestCase]
    public void AssertIsTypeWithComplexGenerics()
    {
        var dict = new Dictionary<string, List<int>>();

        Assert.Is<Dictionary<string, List<int>>>(dict);
        Assert.Is<Dictionary<int, List<char>>>(dict);
        Assert.IsNot<Dictionary<string, List<int>>>(dict);

        //  TODO: next List<(string s, int i)> generic types and tuples :D
    }
}
