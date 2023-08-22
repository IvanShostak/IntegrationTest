using NUnit.Framework;
using Serilog;

namespace LearningLogging.Helpers;

public static class AssertHelper
{
    public static void AssertEqual<T>(
        T actual,
        T expected,
        string field)
    {
        var isEqual = actual.Equals(expected);
        if(isEqual)
        {
            Log.Information($"Correct {field}: actual {actual} is equal {expected}");
        }
        else
        {
            string error = $"!! ERROR: {field} actual {actual} is NOT equal {expected}";
            Log.Error(error);
            throw new Exception(error);
        }
        Assert.IsTrue(isEqual, $"Expected value was {expected}, but was {actual}");
    }
}
