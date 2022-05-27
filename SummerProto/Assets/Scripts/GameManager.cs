using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] PlayerStats[] playerStats;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);

        //singleton pattern

        playerStats = FindObjectsOfType<PlayerStats>();
        // FindObjects can be rough on performance
        // but OK for this small project
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
