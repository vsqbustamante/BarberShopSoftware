using BarberShopSoftware.Server.Models;
using BarberShopSoftware.Server.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BarberShopSoftware.Server.Data;

namespace BarberShopSoftware.Server.Services
{
    public interface IClientService
    {
        Client RegisterClient(ClientDTO clientDTO);
        List<Client> GetWaitingList();
        bool AssignBarber();
    }

    public class ClientService : IClientService
    {
        private readonly List<Client> _clients = new();
        private readonly List<Barber> _barbers = new();

        public Client RegisterClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                Id = _clients.Count + 1,
                Name = clientDTO.Name,
                ContactInfo = clientDTO.ContactInfo,
                IsWaiting = true
            };
            _clients.Add(client);
            return client;
        }

        public List<Client> GetWaitingList()
        {
            return _clients.Where(c => c.IsWaiting).ToList();
        }

        public bool AssignBarber()
        {
            var barber = _barbers.FirstOrDefault(b => b.IsAvailable);
            var client = _clients.FirstOrDefault(c => c.IsWaiting);

            if (barber == null || client == null) return false;

            barber.CurrentClients.Add(client);
            barber.IsAvailable = false;
            client.AssignedBarberId = barber.Id;
            client.IsWaiting = false;

            return true;
        }
    }
}
