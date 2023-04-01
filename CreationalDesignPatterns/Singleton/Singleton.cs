using System;

namespace Singleton
{
    public class Singleton
    {
        public static Singleton instance;
        public readonly static object field = new Object();
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            lock(field)
            {
                if (instance is null)
                    instance = new Singleton();
            }
            return instance;
        }
    }

    public class Program
    {
        public class Client
        {
            public void ClientCode()
            {
                var singleton1 = Singleton.GetInstance();
                var singleton2 = Singleton.GetInstance();

                if (singleton1.Equals(singleton2))
                    Console.WriteLine("Singleton works. Two instances are the same.");
                else
                    Console.WriteLine("Singleton does not work. Two instances are different.");
            }
        }
        static void Main()
        {
            var client = new Client();
            client.ClientCode();
        }
    }
}