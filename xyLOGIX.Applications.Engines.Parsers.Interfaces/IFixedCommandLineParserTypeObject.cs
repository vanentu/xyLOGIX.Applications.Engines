using xyLOGIX.Applications.Engines.Parsers.Constants;

namespace xyLOGIX.Applications.Engines.Parsers.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// has a particular
    /// <see
    ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Constants.CommandLineParserType" />
    /// .
    /// </summary>
    public interface IFixedCommandLineParserTypeObject
    {
        /// <summary>
        /// A
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Constants.CommandLineParserType" />
        /// value that describes the type of command line parser this object is.
        /// </summary>
        CommandLineParserType CommandLineParserType { get; }
    }
}