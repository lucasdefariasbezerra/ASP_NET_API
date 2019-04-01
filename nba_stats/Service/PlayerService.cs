using nba_stats.Models;
using nba_stats.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nba_stats.Service
{
    public class PlayerService
    {
        private NBAStatsEntities context = new NBAStatsEntities();

        public void save(PlayerDTO dto) {
            var player = new Player()
            {
                name = dto.name,
                position = dto.position,
                number = dto.number,
                franchise = dto.franchiseId
            };
            context.Player.Add(player);
            context.SaveChanges();
        }

        public List<PlayerDTO> getPlayers()
        {
            DbSet<Player> list = context.Player;
            return convertToDTOList(list);
        }

        public PlayerDTO getById(int id) {
            DbSet<Player> players = context.Player;
            DbSet<Franchise> franchises = context.Franchise;
            return getFullPlayer(players, franchises, id);
        }

        private PlayerDTO getFullPlayer(DbSet<Player> players, DbSet<Franchise> franchises, int id) {
            PlayerDTO playerDTO = new PlayerDTO();
            FranchiseDTO franchiseDTO = new FranchiseDTO();
            try
            {
                var query =
                players.Join(franchises, player => player.Franchise1.id, franchise => franchise.id,
                (player, franchise) => new
                {
                    playerId = player.id,
                    playerName = player.name,
                    player.position,
                    player.number,
                    franchiseName = franchise.name,
                    franchiseId = franchise.id,
                    franchise.city,
                    franchise.state,
                    franchise.ginasium
                })
                .Where(player => player.playerId == id).First();

                franchiseDTO.name = query.franchiseName;
                franchiseDTO.city = query.city;
                franchiseDTO.state = query.state;
                franchiseDTO.ginasium = query.ginasium;
                franchiseDTO.id = query.franchiseId;
                playerDTO.id = query.playerId;
                playerDTO.name = query.playerName;
                playerDTO.number = query.number;
                playerDTO.position = query.position;
                playerDTO.franchise = franchiseDTO;

                return playerDTO;
            }
            catch (Exception ex) {
                return null;
            }
            
        } 

        private List<PlayerDTO> convertToDTOList(DbSet<Player> list) {
            List<PlayerDTO> dtos = new List<PlayerDTO>();
            foreach (Player player in list) {
                dtos.Add(convertToDTO(player));
            }
            return dtos;
        }

        private PlayerDTO convertToDTO(Player player) {
            PlayerDTO dto = new PlayerDTO();
            dto.id = player.id;
            dto.name = player.name;
            dto.position = player.position;
            dto.number = player.number;
            dto.franchiseId = player.franchise;
            return dto;
        }
    }
}