using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayer : MonoBehaviour
{

    public Text CoinText;
    public Text KeyText;

    public void OnChangeInventory(Dictionary<PickUp.Type, int> inventory)
    {
        int nb_coins = 0;
        int nb_keys = 0;
        inventory.TryGetValue(PickUp.Type.Coin, out nb_coins);
        inventory.TryGetValue(PickUp.Type.Key, out nb_keys);
        CoinText.text = nb_coins.ToString();
        KeyText.text = nb_keys.ToString();
    }
}