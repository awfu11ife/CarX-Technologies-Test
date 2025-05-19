using Runtime.Core.Services;
using Runtime.GamePlay.Projectiles;
using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CrystalTower
{
    public class CrystalShooting : IShootingStrategy
    {
        private readonly ComponentPoolService _pool;
        private readonly Transform _muzzle;
        
        private float _lastFireTime;

        public CrystalShooting(Transform muzzle)
        {
            _muzzle = muzzle;
            _pool = ServiceLocator.Resolve<ComponentPoolService>();
        }

        public void TryShoot(ITargetable target, TowerConfig config)
        {
            if (config == null || Time.time - _lastFireTime < 1f / config.FireRate)
                return;

            _lastFireTime = Time.time;

            var projectile = _pool.Spawn(
                config.ProjectilePrefab,
                _muzzle.position,
                Quaternion.identity
            );

            if (projectile.TryGetComponent(out HomingProjectile homing))
                homing.Launch(target, config.ProjectileSpeed);
        }
    }
}