using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theia.Models.SettingsSystem;

namespace Theia.Services
{
    public class SettingsDataStore : IDataStore<SettingsProfile>
    {
        private Settings settings;
        public Task<bool> AddItemAsync(SettingsProfile item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<SettingsProfile> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettingsProfile>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(SettingsProfile item)
        {
            throw new NotImplementedException();
        }
    }
}
