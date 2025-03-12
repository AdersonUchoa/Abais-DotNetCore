using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Interfaces
{
    public interface AluguelInterfaceRepository
    {
        Task<Aluguel?> GetAluguelById(int aluguelId);
        void PostAluguel(Aluguel aluguel);
        void DeleteAluguel(Aluguel aluguel);
        void PutAluguel(Aluguel aluguel);
        Task<IEnumerable<Aluguel>> GetAllAlugueis();
        Task<bool> SaveAllAsync();
    }
}
