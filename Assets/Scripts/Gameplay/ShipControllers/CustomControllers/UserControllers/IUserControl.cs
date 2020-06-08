using Gameplay.Core;

namespace Gameplay.ShipControllers
{
    public interface IUserControl : IUnityComponent
    {
        float X { get; }
        bool Key { get; }
    }
}
