using YellowNotes.Api.Models;

namespace YellowNotes.Api.Interfaces
{
    public interface IClientService
    {
        ClientModel GetClient(string clientId);
    }
}