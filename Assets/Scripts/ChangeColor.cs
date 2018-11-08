using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Button[] Season_Icons;
    public GameObject[] Season_Play_Button;
    public GameObject[] Season_About_Button;
    public GameObject[] Season_Exit_Button;
    public GameObject[] Season_SoundON_Button;
    public GameObject[] Season_SoundOFF_Button;
    public Button[] Switch_Sound_Button;
    public GameObject[] Switch_GroupSound_Button;
    public Text[] Season_Text;
    public Color[] Colors;

    private int CurrentSeason = (int)Season.Spring;
    private bool Sound = true;
    private enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    };

    private enum SwitchStatus
    {
        ON,
        OFF
    };

    // Use this for initialization
    void Start()
    {
        Season_Icons[(int)Season.Spring].onClick.AddListener(() => ButtonClicked((int)Season.Spring));
        Season_Icons[(int)Season.Summer].onClick.AddListener(() => ButtonClicked((int)Season.Summer));
        Season_Icons[(int)Season.Winter].onClick.AddListener(() => ButtonClicked((int)Season.Winter));
        Season_Icons[(int)Season.Autumn].onClick.AddListener(() => ButtonClicked((int)Season.Autumn));

        Switch_Sound_Button[(int)SwitchStatus.ON].onClick.AddListener(() => SoundClicked((int)SwitchStatus.OFF));
        Switch_Sound_Button[(int)SwitchStatus.OFF].onClick.AddListener(() => SoundClicked((int)SwitchStatus.ON));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void clearSetActive()
    {
        int count = -1;

        while (++count <= (int)Season.Winter)
        {
            Season_Play_Button[count].SetActive(false);
            Season_About_Button[count].SetActive(false);
            Season_Exit_Button[count].SetActive(false);
            Season_SoundON_Button[count].SetActive(false);
            Season_SoundOFF_Button[count].SetActive(false);
        }
    }

    void SoundClicked(int buttonNo)
    {
        int count = -1;

        if (buttonNo == (int)SwitchStatus.OFF)
        {
            Sound = false;
            while (++count <= (int)Season.Winter)
            {
                Season_SoundON_Button[count].SetActive(false);
                Season_SoundOFF_Button[count].SetActive(false);
            }
            Switch_GroupSound_Button[(int)SwitchStatus.ON].SetActive(false);
            Switch_GroupSound_Button[(int)SwitchStatus.OFF].SetActive(true);
            Season_SoundOFF_Button[(int)CurrentSeason].SetActive(true);
        }
        else
        {
            Sound = true;
            while (++count <= (int)Season.Winter)
            {
                Season_SoundON_Button[count].SetActive(false);
                Season_SoundOFF_Button[count].SetActive(false);
            }
            Switch_GroupSound_Button[(int)SwitchStatus.ON].SetActive(true);
            Switch_GroupSound_Button[(int)SwitchStatus.OFF].SetActive(false);
            Season_SoundON_Button[(int)CurrentSeason].SetActive(true);
        }
    }

    void ButtonClicked(int buttonNo)
    {
        CurrentSeason = buttonNo;
        clearSetActive();
        Season_Play_Button[buttonNo].SetActive(true);
        Season_About_Button[buttonNo].SetActive(true);
        Season_Exit_Button[buttonNo].SetActive(true);

        int count = -1;
        while (++count < Season_Text.Length)
        {
            Season_Text[count].color = Colors[buttonNo];
        }

        if (Sound)
        {
            Season_SoundON_Button[buttonNo].SetActive(true);
        }
        else
            Season_SoundOFF_Button[buttonNo].SetActive(true);

    }
}
