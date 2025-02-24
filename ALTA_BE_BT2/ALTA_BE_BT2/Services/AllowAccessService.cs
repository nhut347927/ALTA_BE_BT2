using ALTA_BE_BT2.Data;
using ALTA_BE_BT2.Models;
using Microsoft.EntityFrameworkCore;

namespace ALTA_BE_BT2.Services
{
    public class AllowAccessService : IAllowAccessService
    {
        private readonly ApplicationDbContext _context;

        public AllowAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllowAccess>> GetAllAllowAccessesAsync()
        {
            return await _context.AllowAccesses.Include(aa => aa.Role).ToListAsync();
        }

        public async Task<AllowAccess?> GetAllowAccessByIdAsync(int id)
        {
            return await _context.AllowAccesses.Include(aa => aa.Role).FirstOrDefaultAsync(aa => aa.AllowAccessId == id);
        }

        public async Task AddAllowAccessAsync(AllowAccess allowAccess)
        {
            _context.AllowAccesses.Add(allowAccess);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAllowAccessAsync(AllowAccess allowAccess)
        {
            _context.AllowAccesses.Update(allowAccess);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllowAccessAsync(int id)
        {
            var allowAccess = await _context.AllowAccesses.FindAsync(id);
            if (allowAccess != null)
            {
                _context.AllowAccesses.Remove(allowAccess);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<string>> GetAllowedColumnsForUserAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return new List<string>();

            var allowAccesses = await _context.AllowAccesses
                .Where(aa => aa.RoleId == user.RoleId && aa.TableName == "Intern")
                .ToListAsync(); // Lấy tất cả các quyền

            // Duyệt qua từng quyền và lấy danh sách cột
            var allowedColumns = new HashSet<string>();
            foreach (var allowAccess in allowAccesses)
            {
                if (!string.IsNullOrEmpty(allowAccess.AccessProperties))
                {
                    foreach (var column in allowAccess.AccessProperties.Split(','))
                    {
                        allowedColumns.Add(column.Trim()); // Loại bỏ khoảng trắng dư thừa
                    }
                }
            }

            return allowedColumns.ToList(); 
        }

    }
}