using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<ItemsManager> itemsList;
    // array : size already defined - difficult to replace empty space
    // list : more dynamic, can remove spaces w/o filling 

    // Start is called before the first frame update
    void Start()
    {   instance = this;

        itemsList = new List<ItemsManager>();
        
        // Debug.Log("new list");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }
    
    public void AddItems(ItemsManager item)
    {
        print(item.itemName + " has been added to inventory");
        itemsList.Add(item);
        print(itemsList.Count);
    }
}
