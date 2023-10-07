using MoneyBankService.Domain.Common;
using MoneyBankService.Domain.Entities;
using MoneyBankService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YourDataContextNamespace; // Reemplaza esto con el espacio de nombres donde tengas tu contexto de base de datos

namespace MoneyBankService.Infrastructure.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly YourDbContext _context; // Reemplaza "YourDbContext" con el nombre de tu contexto de base de datos

        public AccountRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> FindAsync(Expression<Func<Account, bool>> predicate)
        {
            return await _context.Accounts.Where(predicate).ToListAsync();
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task RemoveAsync(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
