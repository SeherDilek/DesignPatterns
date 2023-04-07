using System;

namespace Mediator
{
    public interface IMediator
    {
        public void Notify(object sender);
    }

    public class ComponentA
    {
        private IMediator m;

        public ComponentA(IMediator mediator)
        {
            this.m = mediator;
        }

        public void OperationA()
        {
            m.Notify(this);
        }
    }

    public class ComponentB
    {
        private IMediator m;

        public ComponentB(IMediator mediator)
        {
            this.m = mediator;
        }

        public void OperationB()
        {
            m.Notify(this);
        }
    }

    public class ComponentC
    {
        public IMediator m;

        public ComponentC(IMediator mediator)
        {
            this.m = mediator;
        }

        public void OperationC()
        {
            m.Notify(this);
        }
    }

    public class Mediator : IMediator
    {
        public ComponentA componentA;
        public ComponentB componentB;
        public ComponentC componentC;

        public void Notify(object sender)
        {
            if (sender is ComponentA)
            {
                Console.WriteLine("The mediator is notified by ComponentA.");
                    Console.WriteLine("As a result OperationC will be performed.");
                    componentC.OperationC();
                    Console.WriteLine("The component A doesn't even know what is going on. The fired operation is already completed.");
            }
            else if (sender is ComponentB)
            {
                Console.WriteLine("The mediator is notified by ComponentB Triggers following operation:.");
                componentA.OperationA();
            }
            else if (sender is ComponentC)
            {
                Console.WriteLine("The mediator is notified by ComponentC. Triggers following operation:");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();

            var componentA = new ComponentA(mediator);
            var componentB = new ComponentB(mediator);
            var componentC = new ComponentC(mediator);

            mediator.componentA = componentA;
            mediator.componentB = componentB;
            mediator.componentC = componentC;

            componentA.OperationA();
            componentB.OperationB();
            componentC.OperationC();
        }
    }
}
