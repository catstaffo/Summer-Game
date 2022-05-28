using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;


    public static MenuManager instance;

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
                menu.SetActive(true);
                GameManager.instance.gameMenuOpened = true;
            }
        }
    }       
}
