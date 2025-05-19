using Runtime.Core.Services;
using UnityEngine;
using Runtime.Core.Ticking;
using Runtime.GamePlay.Towers.Behaviors;
using Runtime.Infrastructure.Targeting;

namespace Runtime.GamePlay.Towers.Base
{
    public abstract class BaseTower : MonoBehaviour, ITickable
    {
        [SerializeField] private Transform _weapon;

        private TowerConfig _config;
        private ITargetingStrategy _targeting;
        private IAimingStrategy _aiming;
        private IShootingStrategy _shooting;
        private ITargetable _currentTarget;

        public abstract void Construct(TowerConfig config);
        
        public void Initialize(TowerConfig config,
            ITargetingStrategy targeting,
            IAimingStrategy aiming,
            IShootingStrategy shooting)
        {
            _config = config;
            _targeting = targeting;
            _aiming = aiming;
            _shooting = shooting;

            ServiceLocator.Resolve<TickManager>().Register(this);
        }

        protected virtual void OnDisable()
        {
            ServiceLocator.Resolve<TickManager>().Unregister(this);
        }

        public virtual void Tick()
        {
            _currentTarget = _targeting.FindTarget(_weapon.position, _config.Range);
            
            if (_currentTarget == null)
                return;

            _aiming.Aim(_weapon, _currentTarget, _config);
            _shooting.TryShoot(_currentTarget, _config);
        }
    }
}