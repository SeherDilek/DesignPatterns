using System;

namespace Prototype
{
    // Concrete Prototype
    public class ComponentWithBackReference
    {
        public Prototype Prototype { get; set; }

        public ComponentWithBackReference(Prototype p)
        {
            Prototype = p;
        }

        public ComponentWithBackReference GetMemberWiseClone()
        {
            return this.MemberwiseClone() as ComponentWithBackReference;
        }
    }

    public class Prototype
    {
        public int Primitive { get; set; }
        public ComponentWithBackReference CircularReference { get; set; }

        public Prototype()
        {
            this.CircularReference = new ComponentWithBackReference(this);
        }

        public Prototype Clone()
        {
            Prototype clone = this.MemberwiseClone() as Prototype;
            clone.CircularReference = this.CircularReference.GetMemberWiseClone();
            clone.CircularReference.Prototype = this.MemberwiseClone() as Prototype;
            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.ClientCode();
        }
    }

    class Client
    {
        public void ClientCode()
        {
            Prototype prototype = new Prototype();
            prototype.Primitive = 245;
            prototype.CircularReference = new ComponentWithBackReference(prototype);

            Prototype clone = prototype.Clone();

            if(prototype.Primitive == clone.Primitive)
            {
                Console.Write("Primitive field values have been carried over to a clone. Yay!\n");
            }
            else
            {
                Console.Write("Primitive field values have not been copied. Booo!\n");
            }

            if (prototype.CircularReference != clone.CircularReference)
            {
                Console.Write("Component with back reference has been cloned. Yay!\n");
            }
            else
            {
                Console.Write("Component with back reference has not been cloned. Booo!\n");
            }

            if (clone.CircularReference.Prototype != prototype)
            {
                Console.Write("Component with back reference is not linked to original object. Yay!\n");
            }
            else
            {
                Console.Write("Component with back reference is linked to original object. Booo!\n");
            }
        }
    }
}
