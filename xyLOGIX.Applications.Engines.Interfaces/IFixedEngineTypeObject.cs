using xyLOGIX.Applications.Engines.Constants;

namespace xyLOGIX.Applications.Engines.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// implements functionality only for a particular
    /// <see
    ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
    /// value..
    /// </summary>
    public interface IFixedEngineTypeObject
    {
        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// value that specifies what type of application engine this object implements.
        /// </summary>
        EngineType EngineType { get; }
    }
}