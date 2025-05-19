using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CrystalTower
{
    public class CrystalTower : BaseTower
    {
        [SerializeField] private Transform _muzzle;

        public override void Construct(TowerConfig config)
        {
            Initialize(config,
                new NearestTargetStrategy(),
                new NullAiming(),
                new CrystalShooting(_muzzle));
        }
    }
}