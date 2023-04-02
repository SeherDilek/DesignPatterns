using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class RepeatingState
    {
        public object RepeatingProperty1 {get; private set;}
        public object RepeatingProperty2 {get; private set;}

        public RepeatingState(object p1, object p2)
        {
            this.RepeatingProperty1 = p1;
            this.RepeatingProperty2 = p2;
        }
    }

    public class UniqueState
    {
        public object UniqueStateProperty {get; set;}
    }

    public class Flyweight
    {
        public RepeatingState RepeatingState;

        public Flyweight(RepeatingState repeatingState)
        {
            this.RepeatingState = repeatingState;
        }

        public string Operation(UniqueState uniqueState)
        {
            return "The operation is performed for the unique state.";
        }
    }

    public class FlyweightFactory
    {
        private List<Flyweight> cache;

        public static Flyweight GetFlyweight(RepeatingState repeatingState)
        {
            foreach(var flyweight in cache)
            {
                if (flyweight.RepeatingState.Equals(repeatingState))
                    return flyweight;
            }

            return new Flyweight(repeatingState);
        }
    }
    public class Context
    {
        public UniqueState UniqueState;
        public Flyweight Flyweight;

        public Context(UniqueState uniqueState, RepeatingState repeatingState)
        {
            this.UniqueState = uniqueState;
            this.Flyweight = FlyweightFactory.GetFlyweight(repeatingState);
        }

        public void Operation()
        {
            this.Flyweight.Operation(uniqueState);
        }
    }
}

public class Client
{
    public string ClientCode(Flyweight context)
    {

    }
}