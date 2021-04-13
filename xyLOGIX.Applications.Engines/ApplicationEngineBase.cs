using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using xyLOGIX.Applications.Engines.Constants;
using xyLOGIX.Applications.Engines.Interfaces;

namespace xyLOGIX.Applications.Engines
{
    /// <summary>
    /// Provides definitions of events, methods, properties, as well as
    /// services, that are shared among all <c>ApplicationEngine</c> objects.
    /// </summary>
    /// <typeparam name="T">
    /// Concrete type that you wish to inherit from this class. Must be a child
    /// of <see cref="T:xyLOGIX.Applications.Engines.ApplicationEngineBase" />.
    /// </typeparam>
    public abstract class ApplicationEngineBase<T> : IApplicationEngine
        where T : ApplicationEngineBase<T>, IApplicationEngine
    {
        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:xyLOGIX.Applications.Engines.ApplicationEngineBase" />.
        /// </summary>
        private static readonly Lazy<T> _theInstance =
            new Lazy<T>(CreateInstanceOfT);

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static ApplicationEngineBase() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected ApplicationEngineBase() { }

        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:xyLOGIX.Applications.Engines.ApplicationEngineBase" />.
        /// </summary>
        public static T Instance
            => _theInstance.Value;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        protected string UsageMessage { get; set; } = string.Empty;

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
        public List<string> Arguments { get; protected set; } =
            new List<string>();

        /// <summary>
        /// Gets the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// value
        /// that specifies what type of application engine this object implements.
        /// </summary>
        public abstract EngineType EngineType { get; }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextWriter" />
        /// that allows writing to the standard
        /// error stream.
        /// </summary>
        public TextWriter Error { get; protected set; } = Console.Error;

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextReader" />
        /// that allows reading from the
        /// standard input stream.
        /// </summary>
        public TextReader In { get; protected set; } = Console.In;

        /// <summary>
        /// Gets a reference to an instance of
        /// <see
        ///     cref="T:System.IO.TextWriter" />
        /// that allows writing to the standard
        /// output stream.
        /// </summary>
        public TextWriter Out { get; protected set; } = Console.Out;

        /// <summary>
        /// Gets a value that indicates whether the command-line input should be read.
        /// </summary>
        /// <remarks>
        /// This property is <see langword="false" /> by default.
        /// <para />
        /// Such a value prevents the reading of lines of input from standard
        /// input on startup.
        /// </remarks>
        public bool ShouldReadInput { get; protected set; } = false;

        /// <summary>
        /// Gets a value that indicates whether the application should prompt
        /// the user to press any key to continue upon termination.
        /// </summary>
        public bool ShouldReadKey { get; protected set; } = true;

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
        public virtual int Main(IEnumerable<string> args)
        {
            var result = ExitCodes.FAILURE;

            try
            {
                InitializeArguments(args);

                if (!ValidateArguments())
                {
                    PrintUsageMessage();
                    return ExitCodes.FAILURE;
                }

                InitApplication();

                if (!ShouldReadInput)
                    return InvokeInitInstance()
                        ? ExitCodes.SUCESS
                        : ExitCodes.FAILURE;

                var currentLine = In.ReadLine();
                while (currentLine != null)
                {
                    ProcessCurrentLine(currentLine);
                    currentLine = In.ReadLine();
                }

                result = InvokeInitInstance()
                    ? ExitCodes.SUCESS
                    : ExitCodes.FAILURE;
            }
            catch (Exception ex)
            {
                OnException(ex);

                result = ExitCodes.FAILURE;
            }
            finally
            {
                try
                {
                    result = ExitInstance(result);
                }
                catch (Exception ex)
                {
                    OnException(ex);

                    result = ExitCodes.FAILURE;
                }
            }

            return result;
        }

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
        public virtual int Main(IEnumerable<string> args,
            TextReader inputStream, TextWriter outputStream,
            TextWriter errorStream)
        {
            InitializeStreams(inputStream, outputStream, errorStream);

            return Main(args);
        }

        /// <summary>
        /// Called by the
        /// <see
        ///     cref="M:xyLOGIX.Applications.Engines.ApplicationEngineBase.Main" />
        /// method in order to do processing prior to the termination of the
        /// application, but after the per-instance logic has run.
        /// </summary>
        /// <param name="result">
        /// (Required.) Exit code that has been determined by the rest of the application.
        /// </param>
        /// <returns>
        /// Exit code to return to the operating system. Use
        /// <see
        ///     cref="F:xyLOGIX.Applications.Engines.Constants.ExitCodes.SUCESS" />
        /// for success.
        /// </returns>
        /// <remarks>
        /// The default implementation of this method does nothing but just pass
        /// the input through.
        /// </remarks>
        protected virtual int ExitInstance(int result)
            => result;

        /// <summary>
        /// Called to perform application initialization once per execution.
        /// <para />
        /// This method is called prior to the processing of any input.
        /// </summary>
        /// <remarks>
        /// Overriding this method is optional.
        /// </remarks>
        protected virtual void InitApplication() { }

        /// <summary>
        /// Initializes the list of command-line arguments found in the
        /// <see
        ///     cref="P:xyLOGIX.Applications.Engines.ApplicationEngineBase.Arguments" />
        /// property.
        /// </summary>
        /// <param name="args">
        /// (Required.) Reference to a collection of strings that consist of the
        /// command-line arguments passed to this application, one argument per
        /// element of the collection.
        /// </param>
        /// <remarks>
        /// <b>NOTE:</b> If this method is overriden, the base class must be
        /// called prior to any other processing being done.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="args" />, is passed
        /// a <see langword="null" /> value.
        /// </exception>
        protected virtual void InitializeArguments(IEnumerable<string> args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            Arguments = args.ToList();
        }

        /// <summary>
        /// Called to do processing either after all input has been processed or
        /// on its own.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the application has completed
        /// successfully; false otherwise.
        /// </returns>
        /// <remarks>
        /// This method defines what happens each time a new instance of the
        /// application is executed.
        /// <para />
        /// In the event that the
        /// <see
        ///     cref="P:xyLOGIX.Applications.Engines.ApplicationEngineBase.ShouldReadInput" />
        /// property is <see langword="false" />, this method is called
        /// immediately following the call to the
        /// <see
        ///     cref="M:xyLOGIX.Applications.Engines.ApplicationEngineBase.InitApplication" />
        /// method.
        /// </remarks>
        protected abstract bool InitInstance();

        /// <summary>
        /// Called to provide processing in the event an error occurs.
        /// </summary>
        /// <param name="ex">
        /// A <see cref="T:System.Exception" /> that provides detailed
        /// information on the error.
        /// </param>
        protected abstract void OnException(Exception ex);

        /// <summary>
        /// Defines how each line of application input should be processed.
        /// </summary>
        /// <param name="currentLine">
        /// (Required.) String containing the current line of input text.
        /// </param>
        /// <remarks>
        /// Child classes should silently return if the current line of text is
        /// null or whitespace.
        /// </remarks>
        protected abstract void ProcessCurrentLine(string currentLine);

        /// <summary>
        /// Called to validate the command line arguments.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the arguments are valid;
        /// <see
        ///     langword="false" />
        /// otherwise.
        /// </returns>
        /// <remarks>
        /// The base class method does no processing and always returns true.
        /// </remarks>
        protected virtual bool ValidateArguments()
            => true;

        /// <summary>
        /// Creates an instance of <typeparamref name="T" /> via reflection since
        /// <typeparamref name="T" />'s constructor is expected to be protected.
        /// </summary>
        /// <returns>
        /// Reference to the instance of <typeparamref name="T" /> that will be
        /// used as the sole instance of this class.
        /// </returns>
        private static T CreateInstanceOfT()
            => Activator.CreateInstance(typeof(T), true) as T;

        /// <summary>
        /// Sets the streams referenced by the
        /// <see
        ///     cref="P:xyLOGIX.Applications.Engines.ApplicationEngineBase.In" />
        /// ,
        /// <see
        ///     cref="P:xyLOGIX.Applications.Engines.ApplicationEngineBase.Out" />
        /// ,
        /// and
        /// <see
        ///     cref="P:xyLOGIX.Applications.Engines.ApplicationEngineBase.Error" />
        /// properties to the values provided in the
        /// <paramref
        ///     name="inputStream" />
        /// , <paramref name="outputStream" /> and
        /// <paramref
        ///     name="errorStream" />
        /// parameters.
        /// </summary>
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
        private void InitializeStreams(TextReader inputStream,
            TextWriter outputStream, TextWriter errorStream)
        {
            In = inputStream ??
                 throw new ArgumentNullException(nameof(inputStream));
            Out = outputStream ??
                  throw new ArgumentNullException(nameof(outputStream));
            Error = errorStream ??
                    throw new ArgumentNullException(nameof(errorStream));
        }

        /// <summary>
        /// Invocation harness for the
        /// <see
        ///     cref="M:xyLOGIX.Applications.Engines.ApplicationEngineBase.InitInstance" />
        /// method.
        /// <para />
        /// This harness wraps the invocation in an exception handler and
        /// returns the result of the method or <see langword="false" /> if an
        /// execution exception occurred.
        /// </summary>
        /// <returns>
        /// Result of the
        /// <see
        ///     cref="M:xyLOGIX.Applications.Engines.ApplicationEngineBase.InitInstance" />
        /// method, or <see langword="false" /> if an exception was caught during
        /// execution.
        /// </returns>
        private bool InvokeInitInstance()
        {
            bool result;

            try
            {
                result = InitInstance();
            }
            catch (Exception ex)
            {
                OnException(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Prints the usage message in the event the command-line arguments
        /// cannot be validated.
        /// </summary>
        private void PrintUsageMessage()
        {
            if (string.IsNullOrWhiteSpace(UsageMessage)) return;

            Error?.Write($"Usage:\n\n{UsageMessage}");
        }
    }
}