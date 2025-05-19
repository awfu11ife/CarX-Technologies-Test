using Runtime.Core.Services;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Projectiles
{
    public class HomingProjectile : MonoBehaviour, IPoolable
    {
        private ITargetable _target;
        private GameObject _originalPrefab;
        private float _speed;

        public GameObject OriginalPrefab => _originalPrefab;

        public void Launch(ITargetable target, float speed)
        {
            _target = target;
            _speed = speed;
        }

        public void SetOriginalPrefab(GameObject prefab) => 
            _originalPrefab = prefab;

        private void Update()
        {
            if (_target == null || !_target.IsAlive)
            {
                Despawn();
                return;
            }

            var targetPosition = _target.Transform.position;
            var direction = (targetPosition - transform.position).normalized;
            transform.position += direction * _speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) 
                Despawn();
        }

        private void Despawn()
        {
            ServiceLocator.Resolve<ComponentPoolService>().Despawn(gameObject);
        }
    }
}