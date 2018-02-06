using System;

namespace Assets.Scripts.Model
{
    public class Weapon: Item
    {
        private int _damage;

        public int Damage { get { return _damage; } }

        public Weapon(string name, string desc, float price, string icon, int damage): base(name, desc, price, icon)
        {
            _damage = damage;
        }

        public Weapon(int damage): base("Weapon", "Weapon description.", 10, "sword_broadsword")
        {
            _damage = damage;
        }

        public override string CreateTooltip()
        {
            return String.Format("{0}\n{1}\nDamage: {2}", _name, _description, _damage);
        }
    }
}
