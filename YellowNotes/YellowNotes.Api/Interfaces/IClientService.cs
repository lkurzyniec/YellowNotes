using YellowNotes.Api.Models;

namespace YellowNotes.Api.Interfaces
{
    internal interface IClientService
    {
        ClientModel GetClient(string clientId);
    }
}