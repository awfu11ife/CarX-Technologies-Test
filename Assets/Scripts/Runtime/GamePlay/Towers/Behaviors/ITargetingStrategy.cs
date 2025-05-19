using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.Behaviors
{
    public interface ITargetingStrategy
    {
        ITargetable FindTarget(Vector3 origin, float range);
    }
}