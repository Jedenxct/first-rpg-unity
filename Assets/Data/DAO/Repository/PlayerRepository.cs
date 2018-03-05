using System;
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
            _stream = new FileStream("player.dat", FileMode.OpenOrCreate);

            try
            {
                _formatter.Serialize(_stream, player);
            }
            catch
            {
                Console.WriteLine("Failed to save");
            }
            finally
            {
                _stream.Close();
            } 
        }

        public Player Load()
        {
            _stream = new FileStream("player.dat", FileMode.OpenOrCreate);
            Player player;

            try
            {
                player = _formatter.Deserialize(_stream) as Player;
            }
            catch
            {
                Console.WriteLine("Failed to save");
                return null;
            }
            finally
            {
                _stream.Close();
            }

            return player;
        }
        
    }
}
