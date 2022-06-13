using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public enum ItemType { Item, Weapon, Armor}
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemImage;

    public int amountOfEffect;

    public enum EffectType { HP, Mana}
    public EffectType effectType;

    public int weaponDexterity;
    public int armorDefense;

    public bool isStackable;
    public int amount;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // print("This item is named ~ " + itemName);
            Inventory.instance.AddItems(this);
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
