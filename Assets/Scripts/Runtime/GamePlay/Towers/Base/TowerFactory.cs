using Runtime.Core.Services;
using Runtime.Infrastructure.Pooling;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Base
{
    public class TowerFactory
    {
        private readonly ComponentPoolService _pool = ServiceLocator.Resolve<ComponentPoolService>();

        public BaseTower SpawnTower(TowerConfig config, Transform spawnPoint)
        {
            var instance = _pool.Spawn(config.TowerPrefab, spawnPoint.position, spawnPoint.rotation);
            
            if (instance.TryGetComponent(out BaseTower cannonTower))
            {
                cannonTower.Construct(config);
                return cannonTower;
            }

            Debug.LogError("Prefab doesn't contain BaseTower component.");
            return null;
        }
    }
}