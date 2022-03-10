using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLog.Models.State;

namespace TravelLog.Services.State
{
    public interface IStateService
    {
        Task<bool> CreateStateAsync(StateCreate request);

        Task<StateDetail> GetStateByIdAsync(int stateId);

        Task<IEnumerable<StateListItem>> GetAllStatesAsync();

        Task<bool> UpdateStateAsync(StateUpdate request);

        Task<bool> DeleteStateAsync(int stateId);
    }
}