using System;

namespace Visitor
{
    public interface IComponent
    {
        public void Accept(IVisitor visitor);
    }

    public class ComponentA : IComponent
    {
        public string FeatureA()
        {
            return "A";
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ComponentB : IComponent
    {
        public string FeatureB()
        {
            return "B";
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        public void Visit(ComponentA componentA);
        public void Visit(ComponentB componentB);
    }

    class Visitor1 : IVisitor
    {
        public void Visit(ComponentA elementA)
        {
            Console.WriteLine(elementA.FeatureA() + " + Visitor1");
        }

        public void Visit(ComponentB elementB)
        {
            Console.WriteLine(elementB.FeatureB() + " + Visitor1");
        }
    }

    class Visitor2 : IVisitor
    {
        public void Visit(ComponentA elementA)
        {
            Console.WriteLine(elementA.FeatureA() + " + Visitor2");
        }

        public void Visit(ComponentB elementB)
        {
            Console.WriteLine(elementB.FeatureB() + " + Visitor2");
        }
    }

    public class Client
    {
        // The client code can run visitor operations over any set of elements
        // without figuring out their concrete classes. The accept operation
        // directs a call to the appropriate operation in the visitor object.
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (IComponent component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
            {
                new ComponentA(),
                new ComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new Visitor1();
            Client.ClientCode(components,visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new Visitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}