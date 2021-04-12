using System.Collections.Generic;
using xyLOGIX.Applications.Engines.Parsers.Models.Interfaces;

namespace xyLOGIX.Applications.Engines.Parsers.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a Command Line
    /// Parser object.
    /// </summary>
    /// <remarks>
    /// This object consumes the collection of strings that is passed to the
    /// application for its command-line parameters, and then returns a
    /// reference to an instance of an object that implements the
    /// <see
    ///     cref="T:xyLOGIX.Applications.Engines.Parsers.Models.Interfaces.ICommandLineInfo" />
    /// interface, which represents the data obtained from the command line.
    /// </remarks>
    public interface ICommandLineParser : IFixedCommandLineParserTypeObject
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
        ICommandLineInfo Parse(IList<string> args);
    }
}