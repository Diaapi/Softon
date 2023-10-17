using Microsoft.EntityFrameworkCore;
using Softon.Server.Data;
using Softon.Shared;

namespace Softon.Server.Services
{
    public class AppServices : IAppServices
    {
        private AppDbContext _dbContext;
        public AppServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            AppModel? user = _dbContext.apps.Find(id);
            if (user != null)
            {
                _dbContext.apps.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<List<AppModel>> GetApps(string user)
        {
            return await _dbContext.apps.Where(x=>x.User!.ToLower().Contains(user.ToLower())).ToListAsync();
        }

        public async Task Insert(AppModel app)
        {
            _dbContext.apps.Add(app);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AppModel>> Search(string name)
        {
            return await _dbContext.apps.Where(x => x.Name!.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}
