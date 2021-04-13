using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
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
        /// Initializes static data or performs actions that need to be
        /// performed once only for the <see cref="T:MyConsoleApp.Program" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any static members are referenced.
        /// </remarks>
        static Program()
            => LoggingServices.DefaultBackend = new ConsoleLoggingBackend();

        /// <summary>
        /// Provides the application entry point.
        /// </summary>
        /// <param name="args">
        /// (Required.) Collection of strings, each of which is one of the
        /// command-line elements passed to the application.
        /// </param>
        public static void Main(string[] args)
            => GetApplicationEngine.For<MyConsoleApplicationEngine>(
                                       EngineType.DefaultConsole
                                   )
                                   .Main(args);
    }
}