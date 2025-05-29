using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Data.IRepository;
using LibraryManagement.Data.Repository;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.IServices;

namespace LibraryManagement.Services.Services;
public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IBookRepository _bookRepository;

    public ClientService(IClientRepository clientRepository, IBookRepository bookRepository)
    {
        _clientRepository = clientRepository;
        _bookRepository = bookRepository;
    }

    private bool IsClientDtoValid(ClientDto clientDto)
    {
        return !string.IsNullOrWhiteSpace(clientDto.FirstName) &&
               !string.IsNullOrWhiteSpace(clientDto.LastName) &&
               !string.IsNullOrWhiteSpace(clientDto.Address) &&
               !string.IsNullOrWhiteSpace(clientDto.MembershipCardNumber) &&
               clientDto.MembershipCardValidityDate > DateTime.Now &&
               clientDto.LoanDate < clientDto.ReturnDate;
    }

    public async Task<ResponseObject<List<Client>>> GetAllClientsAsync()
    {
        var clients = await _clientRepository.GetAllClientsAsync();

        return clients == null || clients.Count == 0
            ? new ResponseObject<List<Client>> { Data = null, Message = "No clients found", Success = false }
            : new ResponseObject<List<Client>> { Data = clients, Message = "Clients successfully fetched", Success = true };
    }

    public async Task<ResponseObject<Client>> GetClientByIdAsync(int id)
    {
        var client = await _clientRepository.GetClientByIdAsync(id);

        return client == null
            ? new ResponseObject<Client> { Data = null, Message = $"Client with ID {id} not found!", Success = false }
            : new ResponseObject<Client> { Data = client, Message = $"Client with ID {id} found!", Success = true };
    }

    public async Task<ResponseObject<Client>> CreateClientAsync(ClientDto clientDto)
    {
        if (!IsClientDtoValid(clientDto))
        {
            return new ResponseObject<Client> { Data = null, Message = "All fields must be filled correctly", Success = false };
        }

        List<Book> books = await _bookRepository.FindBooksByIds(clientDto.BookIds);


        var client = new Client
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            DOB = clientDto.DOB,
            Address = clientDto.Address,
            MembershipCardNumber = clientDto.MembershipCardNumber,
            MembershipCardValidityDate = clientDto.MembershipCardValidityDate,
            LoanDate = clientDto.LoanDate,
            ReturnDate = clientDto.ReturnDate,
            Books = books
        };

        await _clientRepository.CreateClientAsync(client);

        return new ResponseObject<Client> { Data = client, Message = "Client successfully created!", Success = true };
    }

    public async Task<ResponseObject<Client>> UpdateClientAsync(int id, ClientDto clientDto)
    {
        var clientToUpdate = await _clientRepository.GetClientByIdAsync(id);

        if (clientToUpdate == null)
        {
            return new ResponseObject<Client> { Data = null, Message = $"Client with ID {id} not found!", Success = false };
        }

        if (!IsClientDtoValid(clientDto))
        {
            return new ResponseObject<Client> { Data = null, Message = "All fields must be filled correctly", Success = false };
        }

        List<Book> books = await _bookRepository.FindBooksByIds(clientDto.BookIds);

        clientToUpdate.FirstName = clientDto.FirstName;
        clientToUpdate.LastName = clientDto.LastName;
        clientToUpdate.DOB = clientDto.DOB;
        clientToUpdate.Address = clientDto.Address;
        clientToUpdate.MembershipCardNumber = clientDto.MembershipCardNumber;
        clientToUpdate.MembershipCardValidityDate = clientDto.MembershipCardValidityDate;
        clientToUpdate.LoanDate = clientDto.LoanDate;
        clientToUpdate.ReturnDate = clientDto.ReturnDate;
        clientToUpdate.Books = books;

        await _clientRepository.UpdateClientAsync(id, clientToUpdate);

        return new ResponseObject<Client> { Data = clientToUpdate, Message = "Client successfully updated", Success = true };
    }

    public async Task<ResponseObject<Client>> DeleteClientByIdAsync(int id)
    {
        var client = await _clientRepository.GetClientByIdAsync(id);

        if (client == null)
        {
            return new ResponseObject<Client> { Data = null, Message = $"Client with ID {id} not found!", Success = false };
        }

        await _clientRepository.DeleteClientAsync(client);

        return new ResponseObject<Client> { Data = client, Message = $"Client with ID {id} deleted!", Success = true };
    }
}

