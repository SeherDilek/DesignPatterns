
// Device
public interface IImplementor
{
    public string operationImplementation();
}

// Radio
public class ConcreteImplementorA : IImplementor
{
    public string operationImplementation()
    {
        return "ConcreteImplementationA: The result in platform A.\n";
    }
}

// TV
public class ConcreteImplementorB : IImplementor
{
    public string operationImplementation()
    {
        return "ConcreteImplementationB: The result in platform B.\n";
    }
}

// Remote
public abstract class Abstraction
{
    protected IImplementor implementor;

    public IImplementor Implementor
    {
        set { implementor = value; }
        get { return implementor; }
    }

    public Abstraction(IImplementor imp)
    {
        this.implementor = imp;
    }

    public virtual string Operation()
    {
        return "Abstract: Base operation with:\n" + implementor.operationImplementation();
    }
}

// Advanced Remote
public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction (IImplementor imp) : base(imp)
    {

    }

    public override string Operation()
    {
        return "RefinedAbstraction: Refined operation with:\n" + base.implementor.operationImplementation();
    }
}

class Client
{
    public void ClientCode(Abstraction abstraction)
    {
        Console.WriteLine(abstraction.Operation());
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var client = new Client();
        Abstraction abstraction;
        // Radio remote
        abstraction = new RefinedAbstraction(new ConcreteImplementorA());
        client.ClientCode(abstraction);
        // Change remote device into TV
        abstraction.Implementor = new ConcreteImplementorB();
        client.ClientCode(abstraction);
    }
}