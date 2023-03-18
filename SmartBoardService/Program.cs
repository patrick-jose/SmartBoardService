using ReceiveMessages;

namespace SmartBoardService
{
    class Program
    {
        private static Timer _timer;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void TimerElapsed(object state)
        {
            var receive = new Receive();

            receive.StartListening();          
        }

        static void Main(string[] arqs)
        {
            // Configura o timer para execução do ping e inicia
            // sua execução imediata
            _timer = new Timer(
                 callback: TimerElapsed,
                 state: null,
                 dueTime: 0,
                 period: 30000);

            // Tratando o encerramento da aplicação com
            // Control + C ou Control + Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Saindo...");

                // Libera a continuação da thread principal
                waitHandle.Set();
            };

            // Aguarda que o evento CancelKeyPress ocorra
            waitHandle.WaitOne();
        }
    }
}

