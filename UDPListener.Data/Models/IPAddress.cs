using System.ComponentModel.DataAnnotations;

namespace UDPListener.Data.Models
{
    public class IPAddress
    {
        public IPAddress()
        {
            this.IPAddressId = Guid.NewGuid();
            this.MessagesTexts = new HashSet<Message>();
        }

        public Guid IPAddressId { get; set; }

        [Required]
        [MaxLength(15)]
        public string IP { get; set; }

        public virtual ICollection<Message> MessagesTexts { get; set; }
    }
}
