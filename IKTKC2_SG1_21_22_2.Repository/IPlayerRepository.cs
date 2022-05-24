using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using System.Linq;

namespace IKTKC2_SG1_21_22_2.Repository
{
    public interface IPlayerRepository
    {
        IQueryable<Player> GetAllPlayers();
        Player GetPlayerById(int playerId);
        void AddPlayer(PlayerDto addedPlayer);
        void UpdatePlayer(int playerId, PlayerDto updatedPlayer);
        void DeletePlayerById(int playerId);
    }
}
