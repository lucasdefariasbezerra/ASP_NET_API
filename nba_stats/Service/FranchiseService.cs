using nba_stats.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nba_stats.Service
{
    public class FranchiseService
    {
        private NBAStatsEntities context = new NBAStatsEntities(); 

        public int saveFranchise(FranchiseDTO franchiseDto) {
            Franchise franchise = convertToFranchise(franchiseDto);
            context.Franchise.Add(franchise);
            context.SaveChanges();
            return 1;
        }

        public FranchiseDTO getFranchise(int id) {
            Franchise franchise = context.Franchise.Find(id);
            if (franchise != null)
            {
                return convertToDto(franchise);
            }
            else {
                return null;
            }
            
        }

        public void updateFields(Franchise franchise, FranchiseDTO dto) {
            if (isNotNull(dto.name)) {
                franchise.name = dto.name;
            }

            if (isNotNull(dto.city)) {
                franchise.city = dto.city;
            }

            if (isNotNull(dto.state)) {
                franchise.state = dto.state;
            }

            if (isNotNull(dto.ginasium)) {
                franchise.ginasium = dto.ginasium;
            }
        }

        public int patch(FranchiseDTO dto, int id)
        {
            Franchise franchise = context.Franchise.Find(id);
            if (franchise != null)
            {
                updateFields(franchise, dto);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int put(FranchiseDTO dto, int id) {
            Franchise franchise = context.Franchise.Find(id);
            if (franchise != null) {
                franchise.name = dto.name;
                franchise.city = dto.city;
                franchise.state = dto.state;
                franchise.ginasium = dto.ginasium;
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int delete(int id)
        {
            Franchise franchise = context.Franchise.Find(id);
            if (franchise != null || franchise.active == 1)
            {
                franchise.active = 0;
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<FranchiseDTO> getFranchises() {
            IQueryable<Franchise> list = context.Franchise.Where(f => f.active == 1);
            return convertToDTOList(list);
        }

        private List<FranchiseDTO> convertToDTOList(IQueryable<Franchise> list)
        {
            List<FranchiseDTO> franchises = new List<FranchiseDTO>();
            foreach (Franchise franchise in list)
            {
                FranchiseDTO dto = convertToDto(franchise);
                franchises.Add(dto);
            }
            return franchises;
        }

        private FranchiseDTO convertToDto(Franchise franchise) {
            FranchiseDTO dto = new FranchiseDTO();
            dto.id = franchise.id;
            dto.name = franchise.name;
            dto.city = franchise.city;
            dto.state = franchise.state;
            dto.ginasium = franchise.ginasium;
            return dto;
        }

        private Franchise convertToFranchise(FranchiseDTO franchiseDto)
        {
            var franchise = new Franchise()
            {
                name = franchiseDto.name,
                state = franchiseDto.state,
                city = franchiseDto.city,
                ginasium = franchiseDto.ginasium,
                active = 1
            };
            return franchise;
        }

        private bool isNotNull(String value) {
            return value != null;
        } 
    }
}