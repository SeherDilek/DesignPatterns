using System;

// Also knwon as action, transaction
namespace Command
{
    public class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    public interface ICommand
    {
        public void Execute();
    }

    public class SimpleCommand : ICommand
    {
        private string _payLoad =  string.Empty;

        public SimpleCommand(string payLoad)
        {
            this._payLoad = payLoad;
        }

        public void Execute()
        {
            Console.WriteLine($"Simple Command: See, I can do simple things like printing.");
        }
    }

    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;

        // Context data required to launching the receiver's methods
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
                this._onStart.Execute();
            else
                Console.WriteLine("Nope...");

            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something after I finish?");
            if (this._onFinish is ICommand)
                this._onFinish.Execute();
            else
                Console.WriteLine("Nope...");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Command.Invoker invoker = new Command.Invoker();
        invoker.SetOnStart(new Command.SimpleCommand("Say Hi!"));
        Command.Receiver receiver = new Command.Receiver();
        invoker.SetOnFinish(new Command.ComplexCommand(receiver, "Send email", "Save report"));
        invoker.DoSomethingImportant();
    }
}
