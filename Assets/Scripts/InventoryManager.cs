using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private Dictionary<PickUp.Type, int> items = new Dictionary<PickUp.Type, int>();
    public GameObject Win;

    [SerializeField]
    private InventoryDisplayer inventoryDisplayer;

    void Start()
    {
        inventoryDisplayer.OnChangeInventory(items);
        SceneSwitcher.instance.SetCoins(0);
    }

    public void Add(PickUp pickup)
    {
        PickUp.Type type = pickup.type;

        if (type == PickUp.Type.Gem)
        {
            SceneSwitcher.instance.GoToScene("Congrats");
        }
        else
        {
            int oldTotal = 0;

            if (items.TryGetValue(type, out oldTotal))
                items[type] = oldTotal + 1;
            else
                items.Add(type, 1);
            inventoryDisplayer.OnChangeInventory(items);
        }
        if (PickUp.Type.Coin == type)
        {
            int currentCoins = 0;
            items.TryGetValue(type, out currentCoins);
            SceneSwitcher.instance.SetCoins(currentCoins);
        }
    }

    public bool HasAtLeastOne(PickUp.Type type)
    {
        int value = 0;
        items.TryGetValue(type, out value);
        return value > 0;
    }

    public bool RemoveOne(PickUp.Type type)
    {
        if (HasAtLeastOne(type))
        {
            items[type] -= 1;
            inventoryDisplayer.OnChangeInventory(items);
            return true;
        }
        else return false;
    }
}
