using Runtime.GamePlay.Towers.Base;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Behaviors
{
    public interface IAimingStrategy
    {
        void Aim(Transform weapon, ITargetable target, TowerConfig config);
    }
}