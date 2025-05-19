using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Infrastructure.Targeting
{
    public class TargetRegistry
    {
        private readonly List<ITargetable> _targets = new();

        public void Register(ITargetable target)
        {
            if (!_targets.Contains(target))
                _targets.Add(target);
        }

        public void Unregister(ITargetable target)
        {
            _targets.Remove(target);
        }

        public IReadOnlyList<ITargetable> GetAll() => _targets;

        public ITargetable GetClosestTarget(Vector3 fromPosition, float maxDistance)
        {
            ITargetable closest = null;
            float minDistSqr = maxDistance * maxDistance;

            foreach (var target in _targets)
            {
                if (!target.IsAlive)
                    continue;

                float distSqr = (target.Transform.position - fromPosition).sqrMagnitude;
                if (distSqr < minDistSqr)
                {
                    minDistSqr = distSqr;
                    closest = target;
                }
            }

            return closest;
        }
    }
}