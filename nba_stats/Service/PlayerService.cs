using nba_stats.Models;
using nba_stats.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nba_stats.Service
{
    public class PlayerService : IService<PlayerDTO>
    {
        private NBAStatsEntities context = new NBAStatsEntities();

        
        public int save(PlayerDTO dto)
        {
            var player = new Player()
            {
                name = dto.name,
                position = dto.position,
                number = dto.number,
                franchise = dto.franchiseId,
                active = 1
            };
            context.Player.Add(player);
            context.SaveChanges();
            return 1;
        }

        public List<PlayerDTO> getAll()
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

        

        public int patch(PlayerDTO dto, int id)
        {
            Player player = context.Player.Find(id);
            if (player != null && franchiseExists(dto.franchiseId))
            {
                updateFields(player, dto);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int put(PlayerDTO dto, int id)
        {
            Player player = context.Player.Find(id);
            if (player != null && franchiseExists(dto.franchiseId))
            {
                updateFields(player, dto);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public void updateFields(Player player, PlayerDTO dto)
        {
            if (isNotNull(dto.name))
            {
                player.name = dto.name;
            }

            if (isNotNull(dto.franchiseId)) {
                player.franchise = dto.franchiseId;
            }

            if (isNotNull(dto.number))
            {
                player.number = dto.number;
            }

            if (isNotNull(dto.position))
            {
                player.position = dto.position;
            }
        }

        private bool franchiseExists(int franchiseId) {
            var exists = context.Franchise.Any(franchise => franchise.id == franchiseId);
            return exists;
        }

        private bool isNotNull(String value)
        {
            return value != null;
        }

        private bool isNotNull(int value)
        {
            return value != 0;
        }

        public int delete(int id)
        {
            Player player = context.Player.Find(id);
            if (player != null && player.active == 1)
            {
                player.active = 0;
                context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}