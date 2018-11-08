using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratsManager : MonoBehaviour {

    public Text CoinText;

    private void Update()
    {
        CoinText.text = SceneSwitcher.instance.GetCoins().ToString();
    }
}
