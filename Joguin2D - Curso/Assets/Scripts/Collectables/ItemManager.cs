using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI textCoins;


    private void Reset()
    {
        coins = 0;
        textCoins.text = "x 0";
    }

    public void AddCoin(int ammout = 1) //permite que em ocasioes especiais o ammout seja alterado quando a função é chamada Ex.: Addcoin(5) -> moeda agora vale 5
    {
        coins += ammout;
        textCoins.text = "x " + coins.ToString();
    }
}
