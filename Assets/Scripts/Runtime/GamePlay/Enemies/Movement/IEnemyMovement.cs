using UnityEngine;

namespace Runtime.GamePlay.Enemies.Movement
{
    public interface IEnemyMovement
    {
        Vector3 Move(Vector3 fromPosition, Vector3 toPosition ,float speed, float deltaTime);
    }
}