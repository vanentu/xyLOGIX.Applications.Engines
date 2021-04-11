namespace xyLOGIX.Console.Engine.Constants
{
    /// <summary>
    /// Lists the types of engines that may be manufactured by this library.
    /// </summary>
    public enum EngineType
    {
        /// <summary>
        /// Default application engine that is customized for console applications.
        /// </summary>
        DefaultConsole,

        /// <summary>
        /// Default application engine that is customized for Windows Form applications.
        /// </summary>
        DefaultWinform,

        /// <summary>
        /// Default application engine that is customized for a Windows Service.
        /// </summary>
        DefaultWindowsService,

        /// <summary>
        /// Default application engine.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>.
        /// </summary>
        LoggingWindowsService,

        /// <summary>
        /// Default application engine that is customized for a console application.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>.
        /// </summary>
        LoggingConsole,

        /// <summary>
        /// Application engine that is customized for a Windows Forms application.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>.
        /// </summary>
        LoggingWinform,

        /// <summary>
        /// Application engine, such as for a Windows Service.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>,
        /// where support for <c>PostSharp</c> is also enabled.
        /// </summary>
        PostSharpLoggingWindowsService,

        /// <summary>
        /// Application engine that is customized for a console
        /// application.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>,
        /// where support for <c>PostSharp</c> is also enabled.
        /// </summary>
        PostSharpLoggingConsole,

        /// <summary>
        /// Application engine that is customized for a Windows Forms application.
        /// <para />
        /// This type of engine provides logging services with <c>log4net</c>,
        /// where support for <c>PostSharp</c> is also enabled.
        /// </summary>
        PostSharpLoggingWinform,

        /// <summary>
        /// The type of application engine is unknown.
        /// </summary>
        Unknown = -1
    }
}