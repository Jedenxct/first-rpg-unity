using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Data.Model;

namespace Data.Repository
{
    public class PlayerRepository
    {
        private BinaryFormatter _formatter;
        private FileStream _stream;

        public PlayerRepository()
        {
            _formatter = new BinaryFormatter();
            
        }

        public void Save(Player player)
        {
            _stream = new FileStream("player.dat", FileMode.Create);
            _formatter.Serialize(_stream, player);
        }
        
    }
}
