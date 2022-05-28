using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;


    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] nameText, hpText, manaText, lvlText, xpText;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] Image[] charImage;
    [SerializeField] GameObject[] charPanel;

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("StartFade");
    }

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(menu.activeInHierarchy)
            {
                
                menu.SetActive(false);
                GameManager.instance.gameMenuOpened = false;
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpened = true;
            }
        }
    }    

   public void UpdateStats()
   {
       playerStats = GameManager.instance.GetPlayerStats();
       for (int i=0; i < playerStats.Length; i++)
       {
           charPanel[i].SetActive(true);
           nameText[i].text = playerStats[i].playerName;
           hpText[i].text = "HP: " + playerStats[i].currentHP + "/ " + playerStats[i].maxHP;
           manaText[i].text = "Mana: " + playerStats[i].currentMana + "/ " + playerStats[i].maxMana;
           lvlText[i].text = "Level " + playerStats[i].playerLevel;
           xpText[i].text = "XP: " + playerStats[i].currentXP;

        
           xpSlider[i].maxValue = playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
           xpSlider[i].value = playerStats[i].currentXP;

       }
   }

   public void QuitGame()
   {
       Application.Quit();
       Debug.Log("Game quit");
   }
}
