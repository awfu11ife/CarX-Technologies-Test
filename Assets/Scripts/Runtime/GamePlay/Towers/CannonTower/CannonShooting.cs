using Runtime.Core.Services;
using Runtime.GamePlay.Projectiles;
using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CannonTower
{
    public class CannonShooting : IShootingStrategy
    {
        private readonly ComponentPoolService _pool;
        private readonly Transform _muzzle;
        
        private float _lastShotTime;
        
        public CannonShooting(Transform muzzle)
        {
            _muzzle = muzzle;
            _pool = ServiceLocator.Resolve<ComponentPoolService>();
        }

        public void TryShoot(ITargetable target, TowerConfig config)
        {
            if (config == null || Time.time - _lastShotTime < 1f / config.FireRate)
                return;

            _lastShotTime = Time.time;

            GameObject projectileGO = _pool.Spawn(
                config.ProjectilePrefab,
                _muzzle.position,
                Quaternion.identity
            );

            if (projectileGO.TryGetComponent(out LinearProjectile projectile))
                projectile.Launch(target, config.ProjectileSpeed);
        }
    }
}