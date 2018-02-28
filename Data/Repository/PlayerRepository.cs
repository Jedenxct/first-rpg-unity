using System.Threading.Tasks;
using Data.DAO;

namespace Data.Repository
{
    public class PlayerRepository
    {
        public async Task InsertPlayer(Player player)
        {
            using (var context = DatabaseContext.Get())
            {
                context.Players.Add(player);
                await context.SaveChangesAsync();
            }
        }
    }
}
