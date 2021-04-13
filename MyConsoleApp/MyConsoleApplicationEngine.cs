using System;
using xyLOGIX.Applications.Engines;
using xyLOGIX.Applications.Engines.Constants;

namespace MyConsoleApp
{
    /// <summary>
    /// The engine for my console application.
    /// </summary>
    public class MyConsoleApplicationEngine : DefaultCnsoleApplicationEngineBase<
        MyConsoleApplicationEngine>
    {
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
        protected override bool InitInstance()
        {
            Out.WriteLine("Hello, world!");
            return true;
        }

        /// <summary>
        /// Called to provide processing in the event an error occurs.
        /// </summary>
        /// <param name="ex">
        /// A <see cref="T:System.Exception" /> that provides detailed
        /// information on the error.
        /// </param>
        protected override void OnException(Exception ex)
            => Error.WriteLine(ex);

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
        protected override void ProcessCurrentLine(string currentLine) { }

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
        protected override int ExitInstance(int result)
        {
            Console.ReadKey();
            return ExitCodes.SUCESS;    // ignore exit code provided, just return success
        }
    }
}