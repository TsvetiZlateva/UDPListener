using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPListener.Data.Data;
using UDPListener.Data.Models;

namespace UDPListener.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly ApplicationDbContext db;

        public MessagesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<Message> GetMessagesByDateAndIP(string ip, DateTime dateFrom, DateTime dateTo)
        {
            return this.db.Messages.Where(m => m.IPAddress.IP == ip && m.Date >= dateFrom && m.Date <= dateTo).ToList();
        }

        public async Task PublishMessageAsync(Message message)
        {
            await this.db.Messages.AddAsync(message);
            await this.db.SaveChangesAsync();
        }
    }
}
