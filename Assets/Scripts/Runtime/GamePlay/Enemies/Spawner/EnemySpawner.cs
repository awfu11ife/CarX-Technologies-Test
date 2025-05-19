using UnityEngine;
using Runtime.GamePlay.Enemies.Factory;
using Runtime.GamePlay.Enemies.Base;
using Runtime.GamePlay.Enemies.Movement;

namespace Runtime.GamePlay.Enemies.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [Header("Settings")]
        [SerializeField] private float _spawnInterval = 2f;

        private float _timer;
        private EnemyFactory _factory;

        private void Start()
        {
            _factory = new EnemyFactory();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _spawnInterval)
            {
                _timer = 0f;
                Spawn();
            }
        }

        private void Spawn()
        {
            _factory.SpawnEnemy(_enemyConfig.Prefab, _enemyConfig, new StraightMovement(), _startPoint.position, _endPoint.position);
        }
    }
}