﻿using WebPortal.Models;

namespace WebPortal.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByAsyncId(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}
