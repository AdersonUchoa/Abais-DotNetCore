using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Models;
using ProjetoAbais.API.Interfaces;

namespace ProjetoAbais.API.Repository
{
    public class AluguelRepository : AluguelInterfaceRepository
    {
        private readonly abaisdbContext _context;
        public AluguelRepository(abaisdbContext context)
        {
            _context = context;
        }

        public void DeleteAluguel(Aluguel aluguel)
        {
            _context.Aluguels.Remove(aluguel);
        }

        public async Task<IEnumerable<Aluguel>> GetAllAlugueis()
        {
            return await _context.Aluguels.ToListAsync();
        }

        public async Task<Aluguel?> GetAluguelById(int aluguelId)
        {
            return await _context.Aluguels.Where(x => x.Id == aluguelId).FirstOrDefaultAsync();
        }

        public void PostAluguel(Aluguel aluguel)
        {
            _context.Aluguels.Add(aluguel);
        }

        public void PutAluguel(Aluguel aluguel)
        {
            _context.Entry(aluguel).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
