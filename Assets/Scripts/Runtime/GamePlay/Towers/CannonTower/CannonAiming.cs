using Runtime.GamePlay.Towers.Base;
using Runtime.GamePlay.Towers.Behaviors;
using Runtime.Infrastructure.Targeting;
using UnityEngine;

namespace Runtime.GamePlay.Towers.CannonTower
{
    public class CannonAiming : IAimingStrategy
    {
        public void Aim(Transform weapon, ITargetable target, TowerConfig config)
        {
            Vector3 direction = (target.Transform.position - weapon.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            weapon.rotation = Quaternion.RotateTowards(
                weapon.rotation,
                targetRotation,
                config.RotationSpeed * Time.deltaTime
            );
        }
    }
}