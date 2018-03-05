using System;

namespace Data.Model
{
    [Serializable]
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Level { get; set; }
        public int Scene { get; set; }
        public Location CurrentPosition {get;set;}
    }
}
