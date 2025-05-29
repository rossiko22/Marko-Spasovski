using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.IServices
{
    public interface IClientService
    {
        Task<ResponseObject<Client>> DeleteClientByIdAsync(int id);
        Task<ResponseObject<Client>> UpdateClientAsync(int id, ClientDto clientDto);
        Task<ResponseObject<Client>> CreateClientAsync(ClientDto clientDto);
        Task<ResponseObject<List<Client>>> GetAllClientsAsync();
        Task<ResponseObject<Client>> GetClientByIdAsync(int id);
    }
}
