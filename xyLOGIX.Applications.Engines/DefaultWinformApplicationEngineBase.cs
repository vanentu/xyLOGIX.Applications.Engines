using xyLOGIX.Applications.Engines.Constants;

namespace xyLOGIX.Applications.Engines
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all Default
    /// Console Application engines.
    /// </summary>
    public abstract class
        DefaultWinformApplicationEngineBase : ApplicationEngineBase<
            DefaultWinformApplicationEngineBase>
    {
        /// <summary>
        /// Gets the
        /// <see
        ///     cref="T:xyLOGIX.Applications.Engines.Constants.EngineType" />
        /// value
        /// that specifies what type of application engine this object implements.
        /// </summary>
        public override EngineType EngineType
            => EngineType.DefaultWinform;
    }
}