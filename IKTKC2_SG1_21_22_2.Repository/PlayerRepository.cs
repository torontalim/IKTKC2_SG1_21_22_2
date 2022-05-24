using IKTKC2_SG1_21_22_2.Data;
using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using System;
using System.Linq;

namespace IKTKC2_SG1_21_22_2.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerContext context;

        public PlayerRepository(PlayerContext context)
        {
            this.context = context;
        }

        public IQueryable<Player> GetAllPlayers()
        {
            return context.Players;
        }

        public Player GetPlayerById(int playerId)
        {
            return context.Players.FirstOrDefault(a => a.PlayerId == playerId);
        }

        public void AddPlayer(PlayerDto addedPlayer)
        {
            var newPlayer = new Player()
            {
                Name = addedPlayer.Name,
                Email = addedPlayer.Email,
                PhoneNumber = addedPlayer.PhoneNumber,
                DateOfBirth = addedPlayer.DateOfBirth,
                Active = addedPlayer.Active
            };

            context.Players.Add(newPlayer);
            context.SaveChanges();
        }

        public void UpdatePlayer(int playerId, PlayerDto updatedPlayer)
        {
            var updatable = context.Players.FirstOrDefault(a => a.PlayerId == playerId);

            if (updatable != null)
            {
                updatable.Name = updatedPlayer.Name;
                updatable.Email = updatedPlayer.Email;
                updatable.PhoneNumber = updatedPlayer.PhoneNumber;
                updatable.DateOfBirth = updatedPlayer.DateOfBirth;
                updatable.Active = updatedPlayer.Active;

                context.SaveChanges();
            }
        }

        public void DeletePlayerById(int playerId)
        {
            var deletable = context.Players.FirstOrDefault(a => a.PlayerId == playerId);

            if (deletable != null)
            {
                context.Players.Remove(deletable);
                context.SaveChanges();
            }
        }
    }
}