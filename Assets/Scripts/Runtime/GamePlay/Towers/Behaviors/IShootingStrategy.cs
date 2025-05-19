using Runtime.GamePlay.Towers.Base;
using Runtime.Infrastructure.Targeting;

namespace Runtime.GamePlay.Towers.Behaviors
{
    public interface IShootingStrategy
    {
        void TryShoot(ITargetable target, TowerConfig config);
    }
}