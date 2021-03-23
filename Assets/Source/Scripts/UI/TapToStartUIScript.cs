using Kuhpik;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartUIScript : UIScreen
{
    [SerializeField] Button tapToStartButton;
    
    public override void Subscribe()
    {
        base.Subscribe();
        tapToStartButton.onClick.AddListener(() => Bootstrap.ChangeGameState(EGamestate.Game));
    }
}
