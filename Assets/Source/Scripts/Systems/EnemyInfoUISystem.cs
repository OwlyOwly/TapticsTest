using Kuhpik;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoUISystem : GameSystem, IIniting
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI enemiesLeftText;
    
    void IIniting.OnInit()
    {
        Bootstrap.GetSystem<EnemySpawnSystem>().OnEnemySpawnedEvent += SetEnemyUI;
        SetEnemyUI();
        enemiesLeftText.text = "Left: " + (game.enemyAmount - 1);
    }

    private void SetEnemyUI()
    {
        game.currentEnemy.OnEnemyDamaged += UpdateEnemyHP;
        levelText.text = "Enemy Level: " + game.currentEnemy.GetLevel();
        hpSlider.maxValue = game.currentEnemy.GetMaxHealth();
        hpSlider.value = hpSlider.maxValue;
        enemiesLeftText.text = "Left: " + (game.enemyAmount - game.enemyCount);
    }

    private void UpdateEnemyHP()
    {
        hpSlider.value -= Bootstrap.GetSystem<ClickerSystem>().damagePerClick;
    }
}
