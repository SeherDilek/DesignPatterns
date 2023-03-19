using System;

namespace FactoryMethod
{
    public interface IAbstractProduct
    {
        public void Operation();
    }

    public abstract class AbstractCreator
    {
        public void SomeOperation()
        {
            var product = CreateProduct();
            product.Operation();
        }
        public abstract IAbstractProduct CreateProduct();
    }

    public class ConcreteCreator1 : AbstractCreator
    {
        public override ConcreteProductA CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreator2 : AbstractCreator
    {
        public override IAbstractProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }

    public class ConcreteProductA : IAbstractProduct
    {
        public void Operation()
        {
            Console.WriteLine("ProductA is doing stuff.");
        }
    }

    public class ConcreteProductB : IAbstractProduct
    {
        public void Operation()
        {
            Console.WriteLine("ProductB is doing stuff.");
        }
    } 

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientMethod(new ConcreteCreator1());
            
            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientMethod(new ConcreteCreator2());
        }

        public void ClientMethod(AbstractCreator creator)
        {
            creator.SomeOperation();
        }
    }

    class Program
    {
        static void Main()
        {
            var client = new Client();
            client.Main();
        }
    }
}

