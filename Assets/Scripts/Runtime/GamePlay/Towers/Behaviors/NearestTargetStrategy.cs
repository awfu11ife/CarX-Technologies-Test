using Runtime.Core.Services;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Behaviors
{
    public class NearestTargetStrategy : ITargetingStrategy
    {
        private TargetRegistry _registry;

        public NearestTargetStrategy()
        {
            _registry = ServiceLocator.Resolve<TargetRegistry>();
        }

        public ITargetable FindTarget(Vector3 origin, float range)
        {
            var targets = _registry.GetAll();
            ITargetable closest = null;
            float minSqrDistance = range * range;

            foreach (var target in targets)
            {
                if (!target.IsAlive)
                    continue;

                float sqrDist = (target.Transform.position - origin).sqrMagnitude;
                
                if (sqrDist < minSqrDistance)
                {
                    minSqrDistance = sqrDist;
                    closest = target;
                }
            }

            return closest;
        }
    }
}