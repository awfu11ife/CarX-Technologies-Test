using Runtime.GamePlay.Enemies.Movement;

namespace Runtime.GamePlay.Enemies.Base
{
    public interface IEnemy
    {
        void Initialize(EnemyConfig config, IEnemyMovement movement);
        void Kill();
    }
}