using System.ComponentModel.DataAnnotations;

namespace UDPListener.Data.Models
{
    public class Message
    {
        public Message()
        {
            this.MessageId = Guid.NewGuid();
        }
        public Guid MessageId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(1000)]
        public string MessageText { get; set; }

        public Guid IPAddressId { get; set; }

        public virtual IPAddress IPAddress { get; set; }
    }
}
