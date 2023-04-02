using System;

// Wrapper is the alternative name for the Decorator
// However a wrapper implements the same interface as
// the wrapped object. Make the wrapper's reference field
// accept any object that follows that interface. this will
// let you cover an object in multiple wrappers, adding
// the combined behavor of all the wrappers to it.
// Example -> Notifier in different applications
namespace Decorator
{
    // Declares common interface for both wrappers and
    // wrapped objects
    public abstract class Component
    {
        public abstract string Execute();
    }

    // Can contain both concrete components and decorators
    // Delegates all operations to the wrapped object
    public abstract class Decorator : Component
    {
        protected Component wrappee;

        public Decorator(Component component)
        {
            this.wrappee = component; 
        }

        public override string Execute()
        {
            if (wrappee is not null)
                return wrappee.Execute();
            else
                return string.Empty;
        }
    }

    // Define extra behavior that can be added to the components
    // dynamically
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component component) : base(component)
        {
        }

        public override string Execute()
        {
            return "ConcreteDecoratorA(" + base.Execute() + ")";
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component component) : base(component)
        {
        }

        public override string Execute()
        {
            return "ConcreteDecoratorB(" + base.Execute() + ")";
        }
    }

    // Class of objects being wrapped, defined the basic behavior
    public class ConcreteComponent : Component
    {
        public override string Execute()
        {
            return "ConcreteComponent";
        }
    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Execute());
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var client = new Decorator.Client();
        var simple = new Decorator.ConcreteComponent();
        Console.WriteLine("Client: I get a simple component:");
        client.ClientCode(simple);

        Decorator.ConcreteDecoratorA d1 = new Decorator.ConcreteDecoratorA(simple);
        Decorator.ConcreteDecoratorB d2 = new Decorator.ConcreteDecoratorB(d1);
        Console.WriteLine("Client: Now I get a decorated component:");
        client.ClientCode(d2);
    }
}

