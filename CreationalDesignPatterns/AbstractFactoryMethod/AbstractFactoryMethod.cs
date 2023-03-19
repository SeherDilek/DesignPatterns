using System;

namespace AbstractFactoryMethod
{
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public interface IAbstractProductA
    {

    }

    public interface IAbstractProductB
    {

    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }
        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }
        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public ConcreteProductA1()
        {
            Console.WriteLine("ConcreteProductA1 is created.");
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
        public ConcreteProductA2()
        {
            Console.WriteLine("ConcreteProductA2 is created.");
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public ConcreteProductB1()
        {
            Console.WriteLine("ConcreteProductB1 is created.");
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public ConcreteProductB2()
        {
            Console.WriteLine("ConcreteProductB2 is created.");
        }
    }

    public class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }
        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.Main();
        }
    }
}


