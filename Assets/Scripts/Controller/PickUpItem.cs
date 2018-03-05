using UnityEngine;
using Assets.Scripts.Model;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controller
{
    public class PickUpItem : MonoBehaviour
    {
        private Inventory _inventory;
        private ItemRepository _itemRepository;

        public static List<string> _deletedItemsNames = new List<string>();
        private Item _item;
        private bool _showMessage;

        public int item_id;

        private void Start()
        {
            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            _itemRepository = GameObject.FindGameObjectWithTag("Repository").GetComponent<ItemRepository>();
            _item = _itemRepository.items.Find(repo_item => repo_item.Id == item_id);

            if (_item.Icon != null)
            {
                var sprite = Sprite.Create(_item.Icon, new Rect(0, 0, _item.Icon.width, _item.Icon.height), new Vector2(0.5f, 0.5f));
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var _item = _itemRepository.items.Find(repo_item => repo_item.Id == item_id);

            if (_item != null)
            {
                _showMessage = true;

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    _inventory.AddItem(_item.Id);
                    _deletedItemsNames.Add(gameObject.name);
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _showMessage = false;
        }

        private void OnGUI()
        {
            if (_showMessage)
            {
                var message = String.Format("Pick up: {0}. (enter)", _item.Name);
                GUI.Label(new Rect(Screen.width / 2 + 50, Screen.height / 2, 150, 40), message);
            }
        }

        /// <summary>
        /// This method will delete all gameobjects, that are marked deleted from e.g. previous scenes
        /// </summary>
        private void DisposePreviouslyDeleted()
        {
            for (int i = 0; i < _deletedItemsNames.Count; i++)
            {
                Destroy(GameObject.Find(_deletedItemsNames[i]));
            }
        }

        private void OnLevelWasLoaded(int level)
        {
        DisposePreviouslyDeleted();
        }
    }
}
