using xyLOGIX.Console.Engine.Constants;

namespace xyLOGIX.Console.Engine.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// implements functionality only for a particular
    /// <see
    ///     cref="T:xyLOGIX.Console.Engine.Constants.EngineType" />
    /// value..
    /// </summary>
    public interface IFixedEngineTypeObject
    {
        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Console.Engine.Constants.EngineType" />
        /// value that specifies what type of application engine this object implements.
        /// </summary>
        EngineType EngineType { get; }
    }
}