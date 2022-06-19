namespace UDPListener.Api.DTO
{
    public class MessageDTO
    {
        public Guid MessageId { get; set; }

        public DateTime Date { get; set; }

        public string MessageText { get; set; }

        public string IPAddressId { get; set; }
    }
}
