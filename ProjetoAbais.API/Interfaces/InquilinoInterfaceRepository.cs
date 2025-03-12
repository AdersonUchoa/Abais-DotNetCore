using ProjetoAbais.API.Models;

namespace ProjetoAbais.API.Interfaces
{
    public interface InquilinoInterfaceRepository
    {
        Task<Inquilino?> GetInquilinoById(int inquilinoId);
        void PostInquilino(Inquilino inquilino);
        void DeleteInquilino(Inquilino inquilino);
        void PutInquilino(Inquilino inquilino);
        Task<IEnumerable<Inquilino>> GetAllInquilinos();
        Task<bool> SaveAllAsync();
    }
}
