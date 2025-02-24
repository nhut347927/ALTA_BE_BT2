using ALTA_BE_BT2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALTA_BE_BT2.Services
{
    public interface IInternService
    {
        Task<IEnumerable<object>> GetInternsForUserAsync(int userId);
        Task AddInternAsync(Intern intern);

    }
}