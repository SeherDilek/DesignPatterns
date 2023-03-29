using System;

namespace Singleton
{
    public class Singleton
    {
        public static Singleton instance;
        public readonly string field = "fieldOfSingletonClass";
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }

    public class Program
    {
        public class Client
        {
            public void ClientCode()
            {
                var instance = Singleton.GetInstance();
                Console.WriteLine(instance.field);
            }
        }
        static void Main()
        {
            var client = new Client();
            client.ClientCode();
        }
    }
}