using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    public class GameData
    {
        public Enemy currentEnemy;
        public int enemyAmount = 10;
        public int enemyCount = 1;
        public float latestResult;
        public float totalTime = 60;
    }
}