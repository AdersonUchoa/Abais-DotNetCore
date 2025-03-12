using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Repository
{
    public class InquilinoRepository : InquilinoInterfaceRepository
    {
        private readonly abaisdbContext _context;

        public InquilinoRepository(abaisdbContext context)
        {
            _context = context;
        }

        public void DeleteInquilino(Inquilino inquilino)
        {
            _context.Inquilinos.Remove(inquilino);
        }

        public async Task<IEnumerable<Inquilino>> GetAllInquilinos()
        {
            return await _context.Inquilinos.ToListAsync();
        }

        public async Task<Inquilino?> GetInquilinoById(int inquilinoId)
        {
            return await _context.Inquilinos.Where(x => x.Id == inquilinoId).FirstOrDefaultAsync();
        }

        public void PostInquilino(Inquilino inquilino)
        {
            _context.Inquilinos.Add(inquilino);
        }

        public void PutInquilino(Inquilino inquilino)
        {
            _context.Entry(inquilino).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
