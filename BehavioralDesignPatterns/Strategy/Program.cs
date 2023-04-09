using System;

// An example is navigation app
// there is different options to build a route
// walking, public transportation, driving etc.
// same build route function may be executed
// differently for thos different options

// Lets you alter the behavior of the object at runtime
// by associating it with different sub-objects which
// can perform specific sub-tasks in different ways
namespace Strategy
{
    public interface IStrategy
    {
        public void Execute();
    }

    public class Context
    {
        private IStrategy strategy;

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomething()
        {
            Console.WriteLine("Context: I am doing something using " + this.strategy.GetType().Name);
            strategy.Execute();
        }
    }

    public class StrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("StrategyA: The required functions are executed");
        }
    }

    public class StrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("StrategyB: The required functions are executed.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context();

            var strategyA = new StrategyA();
            context.SetStrategy(strategyA);
            context.DoSomething();

            var strategyB = new StrategyB();
            context.SetStrategy(strategyB);
            context.DoSomething();
        }
    }
}