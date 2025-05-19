using UnityEngine;

namespace Runtime.Infrastructure.Targeting
{
    public interface ITargetable
    {
        Transform Transform { get; }
        Vector3 Velocity { get; }
        bool IsAlive { get; }
    }
}