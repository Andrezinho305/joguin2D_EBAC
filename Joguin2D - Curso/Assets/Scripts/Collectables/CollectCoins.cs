using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : BaseCollectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoin();
    }

}
