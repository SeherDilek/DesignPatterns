using System;

namespace Proxy
{
    public interface IServiceInterface
    {
        public string Operation();
    }

    public class Service : IServiceInterface
    {
        public string Operation()
        {
            return "Service is operating";
        }
    }
    public class Proxy : IServiceInterface
    {
        public Service RealService;

        // Proxy enables you to cache results of the service
        // operations and use them throughtout the lifetime of
        // proxy object without performing the operation again
        // and again
        private string cachedOperation = null;

        public string Operation()
        {
            if (this.CheckAccess())
            {
                RealService = new Service();
                if (cachedOperation is null)
                    cachedOperation = RealService.Operation();

                this.LogAccess();
                return cachedOperation;
            }
            return null;
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }
}

class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Console.WriteLine("Client: Executing the client code with a real subject:");

            Proxy.Service realService = new Proxy.Service();

            client.ClientCode(realService);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");

            Proxy.Proxy proxy = new Proxy.Proxy();

            client.ClientCode(proxy);
        }
    }

    public class Client
    {
        public void ClientCode(Proxy.IServiceInterface proxy)
        {
            proxy.Operation();
        }
    }

