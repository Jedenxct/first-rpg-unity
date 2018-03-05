using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;

public class ItemRepository : MonoBehaviour {

    public static ItemRepository itemRepository;
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        //test


        if (itemRepository == null)
        {
            DontDestroyOnLoad(gameObject);
            itemRepository = this;
        }
        else if (itemRepository != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        items.Add(new Item("That key", "I wonder what it unlocks.", 10, "key_sapphire"));
        items.Add(new Item("Wooden buckler", "At least some protection.", 10, "shield_wooden"));
        items.Add(new Weapon("Broadsword", "Cuts people in half.", 10, "sword_broadsword", 10));
        items.Add(new Consumable("Small health potion", "Heal me up baby!", 10, "potion_health_small", 10));
    }
}