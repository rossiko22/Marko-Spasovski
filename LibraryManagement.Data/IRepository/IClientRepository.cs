using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models.Entities;

namespace LibraryManagement.Data.IRepository
{
    public interface IClientRepository
    {
        Task<Client> GetClientByIdAsync(int Id);
        Task<List<Client>> GetAllClientsAsync();
        Task UpdateClientAsync(int id, Client client);
        Task DeleteClientAsync(Client clientToDelete);
        Task<Client> CreateClientAsync(Client client);
    }
}
