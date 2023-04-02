using System;

namespace Facade
{
    public class Subsystem1
    {
        public string SubsystemOperation1()
        {
            return "Subsystem1: operation 1.\n";
        }

        public string SubsystemOperationN()
        {
            return "Subsytem1: operation N.\n";
        }
    }

    public class Subsystem2
    {
        public string SubsystemOperation1()
        {
            return "Subsystem2: operation 1.\n";
        }

        public string SubsystemOperationN()
        {
            return "Subsytem2: operation N.\n";
        }
    }

    public class Facade
    {
        public Subsystem1 Subsystem1;
        public Subsystem2 Subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this.Subsystem1 = subsystem1;
            this.Subsystem2 = subsystem2;
        }

        public string Operation()
        {
            var result = "Facade performs the first operation with subsystems:\n";
            result += this.Subsystem1.SubsystemOperation1();
            result += this.Subsystem2.SubsystemOperation1();
            result += "Facade performs the operations with subsystems:\n";
            result += this.Subsystem1.SubsystemOperationN();
            result += this.Subsystem2.SubsystemOperationN();
            return result;
        }
    }
}

public class Client
{
    public readonly Facade.Facade Facade;
    public Client(Facade.Facade facade)
    {
        this.Facade = facade;
    }
    public string ClientCode()
    {
        return this.Facade.Operation();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var s1 = new Facade.Subsystem1();
        var s2 = new Facade.Subsystem2();
        var facade = new Facade.Facade(s1, s2);
        var client = new Client(facade);
        Console.WriteLine(client.ClientCode());
    }
}