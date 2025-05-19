using UnityEngine;
using Runtime.GamePlay.Enemies.Base;
using Runtime.GamePlay.Enemies.Movement;
using Runtime.Core.Services;
using Runtime.Infrastructure.Pooling;

namespace Runtime.GamePlay.Enemies.Factory
{
    public class EnemyFactory
    {
        private readonly ComponentPoolService _pool = ServiceLocator.Resolve<ComponentPoolService>();
        private readonly Transform _poolParent;

        public BaseEnemy SpawnEnemy(GameObject prefab, EnemyConfig config, IEnemyMovement movement, Vector3 position, Vector3 targetPosition)
        {
            var spawnedObject = _pool.Spawn(prefab, position, Quaternion.identity);
            
            if (spawnedObject.TryGetComponent(out BaseEnemy enemy))
            {
                enemy.Initialize(config, movement);
                enemy.SetEndPoint(targetPosition);
                return enemy;
            }

            Debug.LogError("Enemy prefab missing BaseEnemy component");
            return null;
        }
    }
}