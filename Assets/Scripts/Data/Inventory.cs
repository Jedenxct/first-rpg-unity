using System;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int slotsX, slotsY;
    public Inventory inventory;
    public static List<Item> slots = new List<Item>();
    public static List<Item> items = new List<Item>();

    private ItemRepository _repository;
    private bool _shown;

    private bool _showTooltip;
    private string _tooltip = "";

    private bool _draggingItem;
    private Item _draggedItem = null;
    private int _originDragIndex;

    private void OnLevelWasLoaded(int level)
    {        
        _shown = false;
    }

    private void Start()
    {
        // search for repository
        _repository = GameObject.Find("Item Repository").GetComponent<ItemRepository>();

        // initialize slots
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            items.Add(new Item());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            _shown = !_shown;
        }
    }

    private void OnGUI()
    {
        var e = Event.current;

        // inventory rendering
        if (_shown)
        {
            DrawInventory();

            if (_showTooltip)
            {
                GUI.Box(new Rect(
                    new Vector2(
                        e.mousePosition.x - 200,
                        e.mousePosition.y - 60),
                        new Vector2(200, 60)), _tooltip);
            }
        }
        
        // drag and drop rendering
        if (_draggingItem)
        {
            GUI.DrawTexture(new Rect(e.mousePosition.x - 32, e.mousePosition.y - 32, 64, 64), _draggedItem.Icon);
        }   
    }

    private void DrawInventory()
    {
        int i = 0;
        _tooltip = "";

        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)             
            {
                var e = Event.current;
                var slotRect = new Rect(
                    Screen.width - x * 50 - 100, 
                    Screen.height - y * 50 - 100, 
                    50, 50); 

                GUI.Box(slotRect, "");

                slots[i] = items[i];

                if (slots[i].Icon != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].Icon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                         _tooltip = slots[i].CreateTooltip();
                        _showTooltip = true;

                        if (e.button == 0 && e.type == EventType.MouseDrag && !_draggingItem)
                        {
                            _draggingItem = true;
                            _originDragIndex = i;
                            _draggedItem = slots[i];
                            items[i] = new Item();
                        }
                        if (e.type == EventType.MouseUp && _draggingItem)
                        {
                            items[_originDragIndex] = items[i];
                            items[i] = _draggedItem;
                            _draggingItem = false;
                            _draggedItem = null;
                        }
                    }                   
                }
                else
                {
                    if (slotRect.Contains(e.mousePosition) && _draggingItem && e.type == EventType.MouseUp)
                    {
                        items[i] = _draggedItem;
                        _draggingItem = false;
                        _draggedItem = null;
                    }
                }

                if (_tooltip == "")
                {
                    _showTooltip = false;
                }

                i++;
            }
        }
    }

    public void AddItem(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Icon == null)
            {
                for (int j = 0; j < _repository.items.Count; j++)
                {
                    if (_repository.items[j].Id == id)
                    {
                        items[i] = _repository.items[j];
                    }
                }
                items[i] = _repository.items[id];
                break;
            }
        }
    }

    private void RemoveItem(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == id)
            {
                items[i] = new Item();
            }
        }
    }

    private bool InventoryContains(int id)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
            {
                return true;
            }         
        }
        return false;
    }
}
