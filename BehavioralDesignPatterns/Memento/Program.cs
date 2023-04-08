using System;
using System.Collections.Generic;

namespace Memento
{
    public class Originator
    {
        public string State;

        public Originator(string state)
        {
            this.State = state;
            Console.WriteLine("My initial state is: " + state);
        }

        public void DoSomething()
        {
            Console.WriteLine("Originator: I am doing something important.");
            this.State = this.GenerateRandomString(30);
            Console.WriteLine("Originator: and my state has changed to " + State );
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        #region  Memento Class
        public interface IMemento
        {
            string GetName();
            string GetState();
            DateTime GetDate();
        }

        public class Memento : IMemento
        {
            private string state;
            private DateTime date;

            internal Memento(string state)
            {
                this.state = state;
                this.date = DateTime.Now;
            }

            public string GetState()
            {
                return this.state;
            }

             public string GetName()
            {
                return $"{this.date} / ({this.state.Substring(0, 9)})...";
            }

            public DateTime GetDate()
            {
                return this.date;
            }
        }
        #endregion
        public void Restore(IMemento m)
        {
            if (!(m is Memento))
                throw new Exception("Unknown memento class " + m.ToString());

            this.State = m.GetState();
            Console.WriteLine("Originator: My state is changed to " + State);
        }

        public IMemento Save()
        {
            return new Memento(this.State);
        }
    }

    public class CareTaker
    {
        private Originator Originator = null;
        private Stack<Originator.IMemento> History = new Stack<Originator.IMemento>();

        public CareTaker(Originator originator)
        {
            this.Originator = originator;
        }

        public void BackUp()
        {
            Console.WriteLine("\nCareTaker: Saving the Originator's state...");
            this.History.Push(this.Originator.Save());
        }

        public void Undo()
        {
            if (this.History.Count == 0)
                return;

            var memento = History.Pop();

            Console.WriteLine("Caretaker: Restoring state to :" + memento.GetName());
            try
            {
                Originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this.History)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var originator = new Originator("Super-duper-puper");
            var careTaker = new CareTaker(originator);

            careTaker.BackUp();
            originator.DoSomething();

            careTaker.BackUp();
            originator.DoSomething();

            careTaker.BackUp();
            originator.DoSomething();

            Console.WriteLine();
            careTaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            careTaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            careTaker.Undo();

            Console.WriteLine();
        }
    }
}
