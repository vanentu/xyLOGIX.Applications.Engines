using System.Collections.Generic;
using System.IO;

namespace xyLOGIX.Applications.Engines.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of all
    /// <c>ApplicationEngine</c> objects.
    /// </summary>
    public interface IApplicationEngine : IFixedEngineTypeObject
    {
        /// <summary>
        /// Gets a reference to a
        /// <see
        ///     cref="T:System.Collections.Generic.List{System.String}" />
        /// that lists
        /// the arguments passed to the application on the command line, one
        /// element per argument.
        /// </summary>
        /// <remarks>
        /// Command-line arguments whose values contain spaces must be in quotes
        /// in order to be parsed as a single argument.
        /// </remarks>
        List<string> Arguments { get; }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextWriter" />
        /// that allows writing to the standard
        /// error stream.
        /// </summary>
        TextWriter Error { get; }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextReader" />
        /// that allows reading from the
        /// standard input stream.
        /// </summary>
        TextReader In { get; }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextWriter" />
        /// that allows writing to the standard
        /// output stream.
        /// </summary>
        TextWriter Out { get; }

        /// <summary>
        /// Gets a value that indicates whether the command-line input should be read.
        /// </summary>
        /// <remarks>
        /// This property is <see langword="false" /> by default.
        /// <para />
        /// Such a value prevents the reading of lines of input from standard
        /// input on startup.
        /// </remarks>
        bool ShouldReadInput { get; }

        /// <summary>
        /// Gets a value that indicates whether the application should prompt
        /// the user to press any key to continue upon termination.
        /// </summary>
        bool ShouldReadKey { get; }

        /// <summary>
        /// Defines the application's entry point.
        /// </summary>
        /// <param name="args">
        /// (Required.) Reference to a collection of strings that consist of the
        /// command-line arguments passed to this application, one argument per
        /// element of the collection.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="args" />, is passed
        /// a <see langword="null" /> value.
        /// </exception>
        /// <remarks>
        /// Child implementations should call the base class when overriding
        /// this method. The main reason for doing so is to customize the exit code.
        /// </remarks>
        int Run(IEnumerable<string> args);

        /// <summary>
        /// Defines the application's entry point.
        /// </summary>
        /// <param name="args">
        /// (Required.) Reference to a collection of strings that consist of the
        /// command-line arguments passed to this application, one argument per
        /// element of the collection.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="args" />, is passed
        /// a <see langword="null" /> value.
        /// </exception>
        /// <param name="inputStream">
        /// (Required.) A <see cref="T:System.IO.TextReader" /> that represents
        /// the program's input stream.
        /// </param>
        /// <param name="outputStream">
        /// (Required.) A <see cref="T:System.IO.TextWriter" /> that represents
        /// the program's output stream.
        /// </param>
        /// <param name="errorStream">
        /// (Required.) A <see cref="T:System.IO.TextWriter" /> that represents
        /// the program's error output stream.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if any of the <paramref name="inputStream" />,
        /// <paramref
        ///     name="outputStream" />
        /// , or <paramref name="errorStream" /> parameters
        /// are passed a <see langword="null" /> reference.
        /// </exception>
        /// <returns>
        /// Integer value that defines the result of the processing. Zero is
        /// returned to indicate that the application completed successfully.
        /// </returns>
        /// <remarks>
        /// Child implementations should call the base class when overriding
        /// this method. The main reason for doing so is to customize the exit code.
        /// </remarks>
        int Run(IEnumerable<string> args, TextReader inputStream,
            TextWriter outputStream, TextWriter errorStream);
    }
}