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
        Log.Information($"Test {TestContext.CurrentContext.Test.Name} has been started");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        _application.Dispose();
        Log.CloseAndFlush();
    }

    internal static void InitializeLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("../../../../log.txt")
            .CreateLogger();
    }

}
