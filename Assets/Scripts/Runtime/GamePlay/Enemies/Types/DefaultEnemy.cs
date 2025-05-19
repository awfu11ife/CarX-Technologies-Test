using UnityEngine;
using Runtime.GamePlay.Enemies.Base;

namespace Runtime.GamePlay.Enemies.Types
{
    public class DefaultEnemy : BaseEnemy
    {
        private void Update()
        {
            Vector3 delta = Movement.Move(transform.position, EndPoint, Config.MoveSpeed, Time.deltaTime);
            transform.position += delta;
            Velocity = delta / Time.deltaTime;

            if (Vector3.Distance(transform.position, EndPoint) < 0.2f)
            {
                Kill();
            }
        }
    }
}