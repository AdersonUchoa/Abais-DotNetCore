using ProjetoAbais.API.Models;


namespace ProjetoAbais.API.Interfaces
{
    public interface AdministradorInterfaceRepository
    {
        Task<Administrador?> GetAdministradorById(int administradorId);
        void PostAdministrador(Administrador administrador);
        void DeleteAdministrador(Administrador administrador);
        void PutAdministrador(Administrador administrador);
        Task<IEnumerable<Administrador>> GetAllAdministradores();
        Task<bool> SaveAllAsync();
    }
}
