using Runtime.Core.Services;
using UnityEngine;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;

namespace Runtime.GamePlay.Enemies.Components
{
    public class EnemyHealth : MonoBehaviour, IPoolable
    {
        private float _health;
        private GameObject _originalPrefab;

        public GameObject OriginalPrefab => _originalPrefab;
        public bool IsAlive => _health > 0;

        public void Initialize(float maxHealth)
        {
            _health = maxHealth;

            ServiceLocator.Resolve<TargetRegistry>().Register(GetComponent<ITargetable>());
        }

        public void SetOriginalPrefab(GameObject prefab) => 
            _originalPrefab = prefab;

        public void TakeDamage(float amount)
        {
            _health -= amount;
            
            if (_health <= 0)
                Kill();
        }

        public void Kill()
        {
            _health = 0;

            ServiceLocator.Resolve<TargetRegistry>().Unregister(GetComponent<ITargetable>());
            ServiceLocator.Resolve<ComponentPoolService>().Despawn(gameObject);
        }
    }
}