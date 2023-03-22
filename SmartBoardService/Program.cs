using ReceiveMessages;

namespace SmartBoardService
{
    class Program
    {
        static void Main(string[] arqs)
        {
            var receive = new Receive();

            receive.StartListening(); 
        }
    }
}

