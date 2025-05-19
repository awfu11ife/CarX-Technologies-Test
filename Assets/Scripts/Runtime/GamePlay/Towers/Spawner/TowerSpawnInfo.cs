using System;
using Runtime.GamePlay.Towers.Base;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Spawner
{
    [Serializable]
    public class TowerSpawnInfo
    {
        [field: Header("References")]
        [field: SerializeField] public TowerConfig TowerConfig { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }
}