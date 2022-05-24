using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using IKTKC2_SG1_21_22_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IKTKC2_SG1_21_22_2.Logic
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public List<Player> GetAllPlayers()
        {
            return playerRepository.GetAllPlayers().ToList();
        }

        public Player GetPlayerById(int playerId)
        {
            return playerRepository.GetPlayerById(playerId);
        }

        public void AddPlayer(PlayerDto addedPlayer)
        {
            CheckPlayerDtoValues(addedPlayer);
            playerRepository.AddPlayer(addedPlayer);
        }

        public void UpdatePlayer(int playerId, PlayerDto updatedPlayer)
        {
            CheckPlayerDtoValues(updatedPlayer);
            playerRepository.UpdatePlayer(playerId, updatedPlayer);
        }

        public void DeletePlayerById(int playerId)
        {
            playerRepository.DeletePlayerById(playerId);
        }

        private void CheckPlayerDtoValues(PlayerDto playerDto)
        {
            string errorMessage = "";

            if (string.IsNullOrEmpty(playerDto.Name))
            {
                errorMessage += "Name cannot be null or empty!\n";
            }

            if (string.IsNullOrEmpty(playerDto.Email))
            {
                errorMessage += "Email cannot be null or empty!\n";
            }
            
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
        }
    }
}