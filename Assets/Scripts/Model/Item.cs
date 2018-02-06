using UnityEngine;
using System;

namespace Assets.Scripts.Model
{
    public class Item: IItem
    {
        private static int _itemCount;
        private int _id;

        protected string _name;
        protected string _description;
        protected float _price;

        private Texture2D _icon;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public float Price { get { return _price; } }
        public Texture2D Icon { get { return _icon; } }

        public Item() { }

        public Item(string name, string description, float price, string icon)
        {
            _id = _itemCount;
            _name = name;
            _description = description;
            _price = price;
            _icon = Resources.Load<Texture2D>("icons/" + icon);

            _itemCount++;
        }

        public virtual string CreateTooltip()
        {
            return String.Format("{0}\n{1}", _name, _description);
        }
    }
}
