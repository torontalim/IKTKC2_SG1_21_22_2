using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKTKC2_SG1_21_22_2.Logic
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player GetPlayerById(int playerId);
        void AddPlayer(PlayerDto addedPlayer);
        void UpdatePlayer(int playerId, PlayerDto updatedPlayer);
        void DeletePlayerById(int playerId);
    }
}
