using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data.IRepository;
using LibraryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repository
{
    public class ClientRepository: IClientRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ClientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Client> GetClientByIdAsync(int Id)
        {
            var client = await _databaseContext.Clients.FirstOrDefaultAsync(client => client.Id == Id);
            return client;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = await _databaseContext.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            await _databaseContext.Clients.AddAsync(client);
            await _databaseContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Client client)
        {

            _databaseContext.Clients.Remove(client);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(int id, Client Client)
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
