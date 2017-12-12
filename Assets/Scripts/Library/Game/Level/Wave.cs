// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    public class Wave
    {
        public int EnemyCount { get; set; }
        public int CoinPerEnemy { get; set; }
        public int HpIncrease { get; set; }
        
        public Wave(int enemyCount, int coinPerEnemy, int hpIncrease)
        {
            EnemyCount = enemyCount;
            CoinPerEnemy = coinPerEnemy;
            HpIncrease = hpIncrease;
        }
    }
}