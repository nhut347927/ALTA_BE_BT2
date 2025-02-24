using ALTA_BE_BT2.Data;
using ALTA_BE_BT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace ALTA_BE_BT2.Services
{
    public class InternService : IInternService
    {
        private readonly ApplicationDbContext _context;

        private readonly IAllowAccessService _allowAccessService;

        public InternService(ApplicationDbContext context, IAllowAccessService allowAccessService)
        {
            _context = context;
            _allowAccessService = allowAccessService;
        }

        public async Task<IEnumerable<Intern>> GetAllInternsAsync()
        {
            return await _context.Interns.ToListAsync();
        }

    public async Task<IEnumerable<object>> GetInternsForUserAsync(int userId)
{
    var allowedColumns = await _allowAccessService.GetAllowedColumnsForUserAsync(userId, "Intern");
    var interns = await _context.Interns.ToListAsync();

    // 📌 Lấy danh sách cột thực tế của bảng Intern
    var entityType = typeof(Intern);
    var allColumns = entityType.GetProperties().Select(p => p.Name).ToHashSet(); // ⚡ Tạo HashSet để tìm kiếm nhanh hơn

    // 🔥 Lọc danh sách cột hợp lệ
    var validColumns = allowedColumns.Where(col => allColumns.Contains(col)).ToList();

    var result = interns.Select(intern =>
    {
        var expando = new ExpandoObject() as IDictionary<string, object>;
        foreach (var column in validColumns) // Chỉ lặp qua các cột hợp lệ
        {
            var propertyInfo = entityType.GetProperty(column);
            expando[column] = propertyInfo?.GetValue(intern);
        }
        return expando;
    });

    return result;
}



        public async Task AddInternAsync(Intern intern)
        {
            intern.DateOfBirth = intern.DateOfBirth?.ToUniversalTime();
            intern.RegisteredDate = intern.RegisteredDate?.ToUniversalTime();
            _context.Interns.Add(intern);
            await _context.SaveChangesAsync();
        }
    }
}