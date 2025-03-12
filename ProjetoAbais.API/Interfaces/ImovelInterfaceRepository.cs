using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Interfaces
{
    public interface ImovelInterfaceRepository
    {
        Task<Imovel?> GetImovelById(int imovelId);
        void PostImovel(Imovel imovel);
        void DeleteImovel(Imovel imovel);
        void PutImovel(Imovel imovel);
        Task<IEnumerable<Imovel>> GetAllImoveis();
        Task<bool> SaveAllAsync();
    }
}
