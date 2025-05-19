using UnityEngine;

namespace Runtime.GamePlay.Towers.Base
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Tower/Config")]
    public class TowerConfig : ScriptableObject
    {
        [field: Header("References")]
        [field: SerializeField] public GameObject TowerPrefab { get; private set; }
        [field: SerializeField] public GameObject ProjectilePrefab { get; private set; }
        [field: Header("Settings")]
        [field: SerializeField] public float Range { get; private set; } = 10f;
        [field: SerializeField] public float FireRate { get; private set; } = 1f;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 180f;
        [field: SerializeField] public float ProjectileSpeed { get; private set; } = 10f;
    }
}