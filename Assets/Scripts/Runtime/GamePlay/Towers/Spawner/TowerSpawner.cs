using System.Collections.Generic;
using Runtime.GamePlay.Towers.Base;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Spawner
{
    public class TowerSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private List<TowerSpawnInfo> _towerSpawnInfos;

        private TowerFactory _towerFactory;
        
        private void Start()
        {
            _towerFactory = new TowerFactory();
            Spawn();
        }

        private void Spawn()
        {
            foreach (var tower in _towerSpawnInfos)
            {
                _towerFactory.SpawnTower(tower.TowerConfig, tower.SpawnPoint);
            }
        }
    }
}