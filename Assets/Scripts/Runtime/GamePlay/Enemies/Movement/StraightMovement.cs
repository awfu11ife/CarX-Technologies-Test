using UnityEngine;

namespace Runtime.GamePlay.Enemies.Movement
{
    public class StraightMovement : IEnemyMovement
    {
        public Vector3 Move(Vector3 fromPosition, Vector3 toPosition,float speed, float deltaTime)
        {
            Vector3 direction = (toPosition - fromPosition).normalized;
            return direction * speed * deltaTime;
        }
    }
}