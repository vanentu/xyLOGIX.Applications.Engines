using System.Collections.Generic;
using xyLOGIX.Applications.Engines.Parsers.Constants;
using xyLOGIX.Applications.Engines.Parsers.Interfaces;
using xyLOGIX.Applications.Engines.Parsers.Models.Interfaces;

namespace xyLOGIX.Applications.Engines.Parsers
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all Command
    /// Line Parser objects.
    /// </summary>
    public abstract class CommandLineParserBase : ICommandLineParser
    {
        /// <summary>
        /// Parses the command line of an application, provided by the
        /// <paramref
        ///     name="args" />
        /// parameter, and provides a reference to an instance of
        /// a POCO that implements the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Models.Interfaces.ICommandLineInfo" />
        /// interface.
        /// </summary>
        /// <param name="args">
        /// (Required.) Collection of strings, each of which represents an
        /// argument passed on the command line.
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Models.Interfaces.ICommandLineInfo" />
        /// interface.
        /// </returns>
        /// <remarks>
        /// What users of this framework will do is inherit an interface for
        /// their custom POCO off of the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Models.Interfaces.ICommandLineInfo" />
        /// interface and derive the concrete type(s) from
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Models.CommandLineInfoBase" />
        /// . This method will then be able to provide the correct parsing behavior.
        /// </remarks>
        public abstract ICommandLineInfo Parse(IList<string> list);

        /// <summary>
        /// A
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Constants.CommandLineParserType" />
        /// value that describes the type of command line parser this object is.
        /// </summary>
        public abstract CommandLineParserType CommandLineParserType { get; }
    }
}