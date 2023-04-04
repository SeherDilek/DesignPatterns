using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);
        public object Handle(object request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler NextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this.NextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this.NextHandler is not null)
                return NextHandler.Handle(request);
            else 
                return null;
        }
    }

    public class HandlerA : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString().Equals("RequestA"))
            {
                return "RequestA is handled in HandlerA.";
            }
            else
                return base.Handle(request);
        }
    }

    public class HandlerB : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString().Equals("RequestB"))
            {
                return "RequestB is handled in HandlerB.";
            }
            else
                return base.Handle(request);
        }
    }

    public class HandlerC : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString().Equals("RequestC"))
                return "RequestC is handled in HandlerC.";
            else
                return base.Handle(request);
        }
    }
}

public class Client
{
    public static void ClientCode(ChainOfResponsibility.AbstractHandler handler)
    {
        foreach (var request in new List<string> {"RequestB", "RequestA", "RequestC", "RequestD"})
        {
            var result = handler.Handle(request);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("The " + request + " couldn't be handled.");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var h1 = new ChainOfResponsibility.HandlerA();
        var h2 = new ChainOfResponsibility.HandlerB();
        var h3 = new ChainOfResponsibility.HandlerC();
        h1.SetNext(h2).SetNext(h3);
        Client.ClientCode(h1);
    }
}
