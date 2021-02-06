using System.Collections.Generic;
using YellowNotes.Api.Models;

namespace YellowNotes.Api.Services
{
    internal interface IClientService
    {
        ClientModel GetClient(string clientId);
    }

    internal class ClientService : IClientService
    {
        private static readonly Dictionary<string, ClientModel> Clients =
            new Dictionary<string, ClientModel>
            {
                ["abc132xyz"] = new ClientModel { ClientId = "abc132xyz", Secret = "/PcwttlSNuzTyfwtkte2srsGFRSWGuwEHWx6cZL1kuQ=", Name = "LK Test Client", Active = true }   //secret123
            };

        public ClientModel GetClient(string clientId)
        {
            return Clients.ContainsKey(clientId) ? Clients[clientId] : null;
        }
    }
}
