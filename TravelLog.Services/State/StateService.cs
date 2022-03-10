using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelLog.Data;
using TravelLog.Data.Entities;
using TravelLog.Models.City;
using TravelLog.Models.Country;
using TravelLog.Models.State;

namespace TravelLog.Services.State
{
    public class StateService : IStateService
    {
        private readonly ApplicationDbContext _dbContext;

        //Constructor
        public StateService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CreateState method
        public async Task<bool> CreateStateAsync(StateCreate request)
        {
            var stateEntity = new StateEntity
            {
                Name = request.Name,
                CountryId = request.CountryId
            };

            _dbContext.States.Add(stateEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //GetAllStates method
        public async Task<IEnumerable<StateListItem>> GetAllStatesAsync()
        {
            var states = await _dbContext.States
                .Select(entity => new StateListItem
                {
                    StateId = entity.StateId,
                    Name = entity.Name
                }).ToListAsync();
            return states;
        }

        //GetStateById method
        public async Task<StateDetail> GetStateByIdAsync(int stateId)
        {
            var stateEntity = await _dbContext.States
                .Include(s => s.Country)
                .Include(s => s.Cities) 
                .FirstOrDefaultAsync(e => e.StateId == stateId);

            return stateEntity is null ? null : new StateDetail
            {
                StateId = stateEntity.StateId,
                Name = stateEntity.Name,
                Country = new CountryListItem()
                {
                    CountryId = stateEntity.Country?.CountryId ?? 0,
                    Name = stateEntity.Country?.Name ?? "State not apart of country"
                },
                Cities = stateEntity.Cities.Select(entity => new CityListItem
                {
                    CityId = entity.CityId,
                    Name = entity.Name
                }).ToList()
            };
        }

        //UpdateState method
        public async Task<bool> UpdateStateAsync(StateUpdate request)
        {
            var stateEntity = await _dbContext.States.FindAsync(request.StateId);

            if (stateEntity == null)
                return false;

            if (!string.IsNullOrWhiteSpace(request.Name))
                stateEntity.Name = request.Name;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        //DeleteState method
        public async Task<bool> DeleteStateAsync(int stateId)
        {
            var stateEntity = await _dbContext.States.FindAsync(stateId);

            if (stateEntity == null)
                return false;

            _dbContext.States.Remove(stateEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }





    }
}