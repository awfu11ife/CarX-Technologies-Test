using UnityEngine;

namespace Runtime.GamePlay.Enemies.Base
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/Config", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [field: Header("References")]
        [field: SerializeField] public GameObject Prefab;
        [field: Header("Settings")]
        [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;
        [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
    }
}