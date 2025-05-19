using UnityEngine;
using Runtime.Infrastructure.Targeting;
using Runtime.GamePlay.Enemies.Movement;
using Runtime.GamePlay.Enemies.Components;

namespace Runtime.GamePlay.Enemies.Base
{
    [RequireComponent(typeof(EnemyHealth))]
    public abstract class BaseEnemy : MonoBehaviour, IEnemy, ITargetable, IDamageable
    {
        [Header("References")]
        [SerializeField] private Transform _body;
        
        private EnemyHealth _health;

        public Vector3 Velocity { get; protected set; }
        public Transform Transform => _body;
        public bool IsAlive => _health.IsAlive;
        protected IEnemyMovement Movement { get; private set; }
        protected EnemyConfig Config { get; private set; }
        protected Vector3 EndPoint { get; private set; }

        public virtual void Initialize(EnemyConfig config, IEnemyMovement movement)
        {
            Config = config;
            Movement = movement;

            _health = GetComponent<EnemyHealth>();
            _health.Initialize(config.MaxHealth);
        }

        public void SetEndPoint(Vector3 endPoint)
        {
            EndPoint = endPoint;
        }
        
        public void TakeDamage(float amount)
        {
            _health.TakeDamage(amount);
        }

        public virtual void Kill()
        {
            _health.Kill();
        }
    }
}