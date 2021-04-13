using xyLOGIX.Applications.Engines.Constants;
using xyLOGIX.Applications.Engines.Interfaces;

namespace xyLOGIX.Applications.Engines.Factories
{
    public static class GetApplicationEngine
    {
        public static IApplicationEngine For<T>(EngineType type) where T : ApplicationEngineBase<T>, IApplicationEngine
        {
            IApplicationEngine engine = null;

            switch (type)
            {
                case EngineType.DefaultConsole:
                    engine = DefaultCnsoleApplicationEngineBase<T>.Instance;
                    break;
            }

            return engine;
        }
    }
}