using UDPListener.Data.Models;

namespace UDPListener.Services
{
    public interface IMessagesService
    {
        ICollection<Message> GetMessagesByDateAndIP(string ip, DateTime dateFrom, DateTime dateTo);

        Task PublishMessageAsync(Message message);
    }
}