using System;
using xyLOGIX.Applications.Engines.Constants;
using xyLOGIX.Applications.Engines.Interfaces;

namespace xyLOGIX.Applications.Engines.Factories
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see
    ///     cref="T:xyLOGIX.Applications.Engines.Interfaces.IApplicationEngine" />
    /// interface and are of the concrete types specified.
    /// </summary>
    public static class GetApplicationEngine
    {
        /// <summary>
        /// Creates a new instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Interfaces.IApplicationEngine" />
        /// interface and returns a reference to it.
        /// </summary>
        /// <typeparam name="T">
        /// Name of a concrete type -- and in, or referable by -- the caller's
        /// own layer of the application, that implements the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Interfaces.IApplicationEngine" />
        /// interface and corresponds to the specified
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// value.
        /// </typeparam>
        /// <param name="type">
        /// One of the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// values
        /// that specifies which type of application engine to create. The type
        /// of engine must correspond to this method's type parameter.
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Interfaces.IApplicationEngine" />
        /// interface.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the specified
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// is not supported.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// Thrown if the type parameter, <typeparamref name="T" />, is not
        /// derived from one of the abstract base classes that correspond to the
        /// <see cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// being requested.
        /// </exception>
        public static IApplicationEngine For<T>(EngineType type)
            where T : ApplicationEngineBase<T>, IApplicationEngine
        {
            IApplicationEngine engine = null;

            switch (type)
            {
                case EngineType.DefaultConsole:
                    if (!typeof(T).IsDerivedFrom(
                        typeof(DefaultConsoleApplicationEngineBase<T>)
                    ))
                        throw new InvalidOperationException(
                            "The generic type, T, must be of a class that inherits DefaultConsoleApplicationEngineBase<T>."
                        );
                    engine = DefaultConsoleApplicationEngineBase<T>.Instance;
                    break;

                case EngineType.DefaultWinform:
                    break;

                case EngineType.DefaultWindowsService:
                    break;

                case EngineType.LoggingWindowsService:
                    break;

                case EngineType.LoggingConsole:
                    break;

                case EngineType.LoggingWinform:
                    break;

                case EngineType.PostSharpLoggingWindowsService:
                    break;

                case EngineType.PostSharpLoggingConsole:
                    break;

                case EngineType.PostSharpLoggingWinform:
                    break;

                case EngineType.Unknown:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(type), type, null
                    );
            }

            return engine;
        }

        /// <summary>
        /// Determines whether the object having the type specified by
        /// <paramref
        ///     name="potentialDescendantType" />
        /// is of a class that inherits from,
        /// or is, the <paramref name="potentialBaseType" />.
        /// </summary>
        /// <param name="potentialDescendantType">
        /// A <see cref="T:System.Type" /> that corresponds to the potential
        /// child class you are testing.
        /// </param>
        /// <param name="potentialBaseType">
        /// A <see cref="T:System.Type" /> that corresponds to the base class or interface.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the
        /// <paramref
        ///     name="potentialDescendantType" />
        /// inherits or is the
        /// <paramref
        ///     name="potentialBaseType" />
        /// ; <see langword="false" /> otherwise.
        /// </returns>
        private static bool IsDerivedFrom(this Type potentialDescendantType,
            Type potentialBaseType)
            => potentialDescendantType.IsSubclassOf(potentialBaseType) ||
               potentialDescendantType == potentialBaseType;
    }
}