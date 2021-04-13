using xyLOGIX.Applications.Engines.Constants;
using xyLOGIX.Applications.Engines.Factories;

namespace MyConsoleApp
{
    /// <summary>
    /// Contains events, methods, and properties for the console application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Provides the application entry point.
        /// </summary>
        /// <param name="args">
        /// (Required.) Collection of strings, each of which is one of the
        /// command-line elements passed to the application.
        /// </param>
        /// <returns>
        /// The exit code of the application. Zero means success.
        /// </returns>
        public static int Main(string[] args)
            => GetApplicationEngine.For<MyConsoleApplicationEngine>(
                                       EngineType.DefaultConsole
                                   )
                                   .Run(args);
    }
}