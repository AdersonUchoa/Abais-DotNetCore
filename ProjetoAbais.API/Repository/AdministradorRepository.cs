using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Repository
{
    public class AdministradorRepository : AdministradorInterfaceRepository
    {
        private readonly abaisdbContext _context;

        public AdministradorRepository(abaisdbContext context)
        {
            _context = context;
        }

        public void DeleteAdministrador(Administrador administrador)
        {
            _context.Administradors.Remove(administrador);
        }

        public async Task<Administrador?> GetAdministradorById(int administradorId)
        {
            return await _context.Administradors.Where(x => x.Id == administradorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Administrador>> GetAllAdministradores()
        {
            return await _context.Administradors.ToListAsync();
        }

        public void PostAdministrador(Administrador administrador)
        {
            _context.Administradors.Add(administrador);
        }

        public void PutAdministrador(Administrador administrador)
        {
            _context.Entry(administrador).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
