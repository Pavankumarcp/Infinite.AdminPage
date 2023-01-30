using Infinite.AdminPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infinite.AdminPage.Repositories
{
    public class RegUserInterface : IRepository<RegUser>
    {
        private readonly ApplicationDbContext _Context;
        public RegUserInterface(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IEnumerable<RegUser> GetAll()
        {
            var users = _Context.Regdusers.Select(m => new RegUser
            {
                Id = m.Id,
                Name = m.Name,
                Username = m.Username,
                Password = m.Password,
                ConfirmPwd = m.ConfirmPwd,
                DOB = m.DOB,
                Email = m.Email,
            }).ToList();
            return users;  
        }

        public async Task<RegUser> Update(int id, RegUser obj)
        {
            var userInDb=await _Context.Regdusers.FindAsync(id);
            if (userInDb!=null)
            {
                userInDb.Id= id;
                userInDb.Name = obj.Name;
                userInDb.Email= obj.Email;
                userInDb.Password= obj.Password;
                userInDb.ConfirmPwd= obj.ConfirmPwd;
                userInDb.DOB= obj.DOB;
                _Context.Regdusers.Update(userInDb);
                await _Context.SaveChangesAsync();
                return userInDb;
            }
            return null;
        }
    }
}
