using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using ProjetoAbais.API.Interfaces;

namespace ProjetoAbais.API.Repository
{
    public class ImovelRepository : ImovelInterfaceRepository
    {
        private readonly abaisdbContext _context;

        public ImovelRepository(abaisdbContext context)
        {
            _context = context;
        }  

        public void DeleteImovel(Imovel imovel)
        {
            _context.Imovels.Remove(imovel);
        }
        public async Task<IEnumerable<Imovel>> GetAllImoveis()
        {
            return await _context.Imovels.ToListAsync();
        }
        public async Task<Imovel?> GetImovelById(int imovelId)
        {
            return await _context.Imovels.Where(x => x.Id == imovelId).FirstOrDefaultAsync();
        }
        public void PostImovel(Imovel imovel)
        {
            _context.Imovels.Add(imovel);
        }
        public void PutImovel(Imovel imovel)
        {
            _context.Entry(imovel).State = EntityState.Modified;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
