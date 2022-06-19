using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPListener.Services;

namespace UDPListener
{
    public abstract class UDPListener
    {
        private const int listenPort = 11000;
        private readonly IMessagesService messagesService;

        private UDPListener(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public static void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    //TODO write in db
                    //await messagesService.PublishMessageAsync(data);
                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
