using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Serilog;

namespace LearningLogging.Scenarios;

internal class BasicScenarios
{
    private static ApplicationRunHelper _application;
    protected static HttpClient HttpClient = new();

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        InitializeLogger();
        _application = new ApplicationRunHelper();
        HttpClient = _application.CreateClient();
    }

    [SetUp]
    public static void SetUp()
    {
        Log.Information($"\n----Test {TestContext.CurrentContext.Test.Name} has been started----\n");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        _application.Dispose();
        Log.CloseAndFlush();
    }

    internal static void InitializeLogger()
    {
        var className = TestContext.CurrentContext.Test.ClassName;
        className = className.Substring(className.LastIndexOf('.') + 1);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File($"../../../Logs/{className}.txt", rollingInterval: RollingInterval.Minute, retainedFileCountLimit: 2)
            .CreateLogger();
    }

}
