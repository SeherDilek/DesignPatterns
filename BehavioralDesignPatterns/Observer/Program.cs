using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public int State {get; set;} = -0;

        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this.observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if (this.observers.Remove(observer))
            {
                Console.WriteLine("Subject: Detached an observer.");
            }
            else
                Console.WriteLine("Subject: Could not detach the observer. Observer couldn't be found.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in this.observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I am doing something important...");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state is changed to: " + this.State);
            this.Notify();
        }
    }

    class ObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
                Console.WriteLine("ObserverA: Reacted to the event.");
        }
    }

    class ObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
                Console.WriteLine("ObserverB: Reacted to the event.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var subject = new Subject();
            var observerA = new ObserverA();
            subject.Attach(observerA);
            var observerB = new ObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
    }
}