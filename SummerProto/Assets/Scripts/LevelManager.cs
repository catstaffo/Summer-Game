using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(1f, 2f, 1f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-1f,-1f,-1f);

        PlayerController.instance.SetLimit(bottomLeftEdge, topRightEdge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
