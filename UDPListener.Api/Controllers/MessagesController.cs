using Microsoft.AspNetCore.Mvc;
using UDPListener.Api.DTO;
using UDPListener.Data.Models;
using UDPListener.Services;

namespace UDPListener.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        [HttpGet(Name = "GetMessagesByDateAndIP")]
        public async Task<IEnumerable<MessageDTO>> Get(string ip, DateTime dateFrom, DateTime dateTo)
        {
            var messages = new List<MessageDTO>();

            try
            {
                messages = messagesService.GetMessagesByDateAndIP(ip, dateFrom, dateTo).Select(m => new MessageDTO
                {
                    MessageId = m.MessageId,
                    MessageText = m.MessageText,
                    Date = m.Date
                }).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return messages;
        }
    }
}
