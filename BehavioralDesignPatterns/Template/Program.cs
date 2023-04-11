using System;

namespace Template
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.BaseOperation1();
            this.RequiredOperations1();
            this.BaseOperation2();
            this.Hook1();
            this.RequiredOperations2();
            this.BaseOperation3();
            this.Hook2();
        }

        protected void BaseOperation1()
        {
            Console.WriteLine("Abstract class: I am doint the bulk of the work.");
        }

        protected void BaseOperation2()
        {
            Console.WriteLine("AbstractClass: But I let subclasses override some operations.");
        }

        protected void BaseOperation3()
        {
            Console.WriteLine("AbstractClass: But I am doing the bulk of the work anyway.");
        }

        protected abstract void RequiredOperations1();
        protected abstract void RequiredOperations2();

        protected virtual void Hook1() { }

        protected virtual void Hook2() { }
    }

    public class ConcreteClass1 : AbstractClass
    {
        protected override void RequiredOperations1()
        {
            Console.WriteLine("ConcreteClass1: Implemented Operation1.");
        }

        protected override void RequiredOperations2()
        {
            Console.WriteLine("ConcreteClass1: Implemented Operation2.");
        }
    }

    public class ConcreteClass2 : AbstractClass
    {
        protected override void RequiredOperations1()
        {
            Console.WriteLine("ConcreteClass2: Implemented Operation1.");
        }

        protected override void RequiredOperations2()
        {
            Console.WriteLine("ConcreteClass2: Implemented Operation2.");
        }
        protected override void Hook1()
        {
            Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
        }
    }

    public class Program
    {
        public static void Main()
        {
            var cc1 = new ConcreteClass1();
            cc1.TemplateMethod();

            var cc2 = new ConcreteClass2();
            cc2.TemplateMethod();
        }
    }
}
