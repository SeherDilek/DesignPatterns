using System;

namespace State
{
    // Document
    public class Context
    {
        private IState state;

        public Context(IState initialState)
        {
            this.state = initialState;
            this.state.SetContext(this);
        }

        public void ChangeState(IState state)
        {
            Console.WriteLine("Context: Transition to " + this.state.GetType().Name);
            this.state = state;
            this.state.SetContext(this);
        }

        public void Request1()
        {
            this.state.Handle1();
        }

        public void Request2()
        {
            this.state.Handle2();
        }
    }

    public interface IState
    {
        public void SetContext(Context context);

        public void Handle1();

        public void Handle2();
    }

    // Draft
    public class StateA : IState
    {
        private Context context;

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void Handle1()
        {
            Console.WriteLine("StateA, Handle1: Request is handled.");
        }

        public void Handle2()
        {
            Console.WriteLine("StateA, Handle2: Request is handled.");
            Console.WriteLine("StateA wants to change the state of the context");
            this.context.ChangeState(new StateB());
        }
    }

    public class StateB : IState
    {
        private Context context;

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void Handle1()
        {
            Console.WriteLine("StateB, Handle1: Request1 is handled.");
        }

        public void Handle2()
        {
            Console.WriteLine("StateB, Handle2: Request2 is handled.");
            Console.WriteLine("StateB wants to change the state of the context");
            this.context.ChangeState(new StateA());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context(new StateA());
            context.Request1();
            context.Request2();

            context.Request1();
            context.Request2();
        }
    }

}
