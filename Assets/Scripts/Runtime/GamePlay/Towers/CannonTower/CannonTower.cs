using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CannonTower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _muzzle;

        public override void Construct(TowerConfig config)
        {
            Initialize(config,
                new NearestTargetStrategy(),
                new CannonAiming(),
                new CannonShooting(_muzzle));
        }
    }
}