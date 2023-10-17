using Softon.Shared;

namespace Softon.Server.Services
{
    public interface IAppServices
    {
        Task<List<AppModel>> GetApps(string user);
        Task<List<AppModel>> Search(string name);
        Task Insert(AppModel app);
        Task Delete(int id);
    }
}
