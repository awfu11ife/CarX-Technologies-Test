using Runtime.Core.Services;
using UnityEngine;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;

namespace Runtime.GamePlay.Projectiles
{
    public class LinearProjectile : MonoBehaviour, IPoolable
    {
        private ITargetable _target;
        private GameObject _originalPrefab;
        private Vector3 _velocity;
        private float _speed;

        public GameObject OriginalPrefab => _originalPrefab;

        public void Launch(ITargetable target, float speed)
        {
            _target = target;
            _speed = speed;
            _velocity = CalculateVelocity();
        }

        public void SetOriginalPrefab(GameObject prefab) => 
            _originalPrefab = prefab;

        private void Update()
        {
            var targetPosition = _target.Transform.position;
            transform.position += _velocity * Time.deltaTime;
            
            if (_velocity != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(_velocity);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) 
                Despawn();
        }

        private void Despawn()
        {
            ServiceLocator.Resolve<ComponentPoolService>().Despawn(gameObject);
        }

        private Vector3 CalculateVelocity()
        {
            Vector3 predictedPos = PredictTargetPosition(
                transform.position,
                _target.Transform.position,
                _target.Velocity,
                _speed
            );

            Vector3 direction = (predictedPos - transform.position).normalized;
            Vector3 velocity = direction * _speed;
            return velocity;
        }
        
        private Vector3 PredictTargetPosition(Vector3 shootPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
        {
            Vector3 toTarget = targetPosition - shootPosition;
            Vector3 relVelocity = targetVelocity;

            float a = Vector3.Dot(relVelocity, relVelocity) - projectileSpeed * projectileSpeed;
            float b = 2f * Vector3.Dot(relVelocity, toTarget);
            float c = Vector3.Dot(toTarget, toTarget);
            float discriminant = b * b - 4f * a * c;

            if (discriminant < 0f || Mathf.Abs(a) < 0.0001f)
                return targetPosition;

            float t = Mathf.Max(0f, (-b - Mathf.Sqrt(discriminant)) / (2f * a));
            return targetPosition + relVelocity * t;
        }
    }
}