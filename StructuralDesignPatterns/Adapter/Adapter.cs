// See https://aka.ms/new-console-template for more information
var adapter = new Adapter();
object data = new object();
adapter.Method(data);
Console.WriteLine("Service is finished.");

public interface IClientInterface
{
    public Service Method(object data);
}

// This is implementation of Adapter
// There is also a Class Adapter pattern
// that uses inheritance. In other words
// the adapter class inherites interfaces from 
// both Client and Service objects at the same
// time. It is not implemented here.
public class Adapter : IClientInterface
{
    public Service adaptee = new Service();

    public Service Method(object data)
    {
        var specialData = ConvertToServiceFormat(data);
        return adaptee.ServiceMethod(specialData);
    }

    public object ConvertToServiceFormat(object data)
    {
        Console.WriteLine("Converting data into special data.");
        return data;
    }
}

public class Service
{
    public Service ServiceMethod(object specialData)
    {
        Console.WriteLine("Service method is recalled with special data.");
        return new Service();
    }
}

