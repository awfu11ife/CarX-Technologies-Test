using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CrystalTower
{
    public class NullAiming : IAimingStrategy
    {
        public void Aim(Transform weapon, ITargetable target, TowerConfig config)
        {
            // Do nothing
        }
    }
}