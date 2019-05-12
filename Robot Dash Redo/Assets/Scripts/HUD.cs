using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    public PlayerController Player;

    private void Update()
    {
        HeartUI.sprite = HeartSprites[Player.curHealth];
    }

}
