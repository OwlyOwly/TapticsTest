using Kuhpik;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : GameSystem, IIniting
{
    public event Action OnEnemySpawnedEvent;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 spawnPosition;
    
    void IIniting.OnInit()
    {
        SpawnNextEnemy();
    }

    private void SpawnNextEnemy()
    {
        if (game.enemyCount <= game.enemyAmount)
        {
            game.currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
            game.currentEnemy.SetStats(game.enemyCount);
            game.currentEnemy.OnEnemyDiedEvent += SpawnNextEnemy;
            OnEnemySpawnedEvent?.Invoke();
            game.enemyCount++;
        }
        else
        {
            game.latestResult = game.totalTime - Bootstrap.GetSystem<TimerSystem>().GetRemainingTime();
            if (game.latestResult <= player.record || player.record == 0)
            {
                player.record = game.latestResult;
            }
            Bootstrap.ChangeGameState(EGamestate.Victory);
        }
    }
}
