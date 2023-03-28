using System;

namespace Prototype
{
    public interface IPrototype
    {
        public abstract IPrototype Clone();
    }

    public class ConcretePrototype : IPrototype
    {
        public object field1;

        ConcretePrototype(ConcretePrototype prototype)
        {
            this.field1 = prototype.field1;
        }

        public override IPrototype Clone()
        {
            return new ConcretePrototype(this);
        }
    }

    public class SubClassPrototype : ConcretePrototype
    {
        public object field2;

        SubClassPrototype(SubClassPrototype prototype)
        {
            this.field2 = prototype.field2;
        }

        public override IPrototype Clone()
        {
            return new SubClassPrototype(this);
        }
    }
}
