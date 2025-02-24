using ALTA_BE_BT2.Models;

namespace ALTA_BE_BT2.Services
{
    public interface IAllowAccessService
    {
        Task<IEnumerable<AllowAccess>> GetAllAllowAccessesAsync();
        Task<AllowAccess?> GetAllowAccessByIdAsync(int id);
        Task AddAllowAccessAsync(AllowAccess allowAccess);
        Task UpdateAllowAccessAsync(AllowAccess allowAccess);
        Task DeleteAllowAccessAsync(int id);
        Task<List<string>> GetAllowedColumnsForUserAsync(int userId, String TableName);
    }
}