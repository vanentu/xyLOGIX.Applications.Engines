namespace xyLOGIX.Applications.Engines.Parsers.Constants
{
    /// <summary>
    /// Values that specify the type of command-line parers to work with.
    /// </summary>
    public enum CommandLineParserType
    {
        /// <summary>
        /// Parsing the command line of a Console Application.
        /// </summary>
        ConsoleApp,

        /// <summary>
        /// Parsing the command line of a Windows Application.
        /// </summary>
        WinFormApp,

        /// <summary>
        /// Parsing the command line of a Windows Service.
        /// </summary>
        WindowsService,

        /// <summary>
        /// The type of command line parser to use is unknown.
        /// </summary>
        Unknown = -1
    }
}