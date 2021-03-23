using Kuhpik;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerSystem : GameSystem
{
    public int damagePerClick = 10;

    public void DealDamage()
    {
        game.currentEnemy.GetDamage(damagePerClick);
    }

    public void ReloadGame()
    {
        Bootstrap.GameRestart(0);
    }
}

