using Runtime.Core.Services;
using Runtime.Core.Ticking;
using Runtime.Infrastructure.Pooling;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.Core
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Transform _pooledObjectsContainer;

        private TickManager _tickManager;

        private void Awake()
        {
            ServiceLocator.Clear();

            _tickManager = new TickManager();
            ServiceLocator.Register(_tickManager);

            var targetRegistry = new TargetRegistry();
            ServiceLocator.Register(targetRegistry);

            var poolService = new ComponentPoolService(_pooledObjectsContainer);
            ServiceLocator.Register(poolService);
        }

        private void Update()
        {
            _tickManager.Tick();
        }
    }
}