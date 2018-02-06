using System;

namespace Assets.Scripts.Model
{
    public class Consumable: Item
    {
        private int _effect;

        public Consumable(string name, string desc, float price, string icon, int effect): base(name, desc, price, icon)
        {
            _effect = effect;
        }

        public override string CreateTooltip()
        {
            return String.Format("{0}\n{1}\nHealing: {2}", _name, _description, _effect);
        }
    }
}
