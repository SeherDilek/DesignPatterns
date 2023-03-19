using System;

namespace Builder
{
    public abstract class Builder
    {
        public abstract void Reset();
        public abstract void BuildStepA();
        public abstract void BuildStepB();
        public abstract void BuildStepZ();
        public abstract Product GetResult();
    }

    public class Director
    {
        public Builder Builder;

        public Director(Builder builder)
        {
            this.Builder = builder;
        }

        public void ChangeBuilder(Builder builder)
        {
            this.Builder = builder;
        }

        public void BuildStandardProduct()
        {
            Builder.BuildStepA();
        }

        public void buildFullFeaturedProduct()
        {
            Builder.BuildStepB();
            Builder.BuildStepZ();
        }
    }

    public class ConcreteBuilder : Builder
    {
        public Product Result = new Product();

        public override void Reset()
        {
            this.Result = new Product();
        }

        public override void BuildStepA()
        {
            Result.SetFeatureA();
        }

        public override void BuildStepB()
        {
            Result.SetFeatureB();
        }

        public override void BuildStepZ()
        {
            Result.SetFeatureZ();
        }

        public override Product GetResult()
        {
            return Result;
        }
    }

    public class Product
    {
        public void SetFeatureA()
        {
            Console.WriteLine("Feature A is set for the Product.");
        }

        public void SetFeatureB()
        {
            Console.WriteLine("Feature B is set for the Product.");
        }

        public void SetFeatureZ()
        {
            Console.WriteLine("Feature Z is set for the Product.");
        }
    }

    class Program
    {
        class Client
        {
            public void ClientCode(Director director, Builder builder)
            {
                Console.WriteLine("Standart product:");
                director.BuildStandardProduct();

                Console.WriteLine("Standart full featured product:");
                director.buildFullFeaturedProduct();

                Console.WriteLine("Custom product:");
                builder.BuildStepA();
                builder.BuildStepB();
            }
        }

        static void Main()
        {
            var client = new Client();
            var builder = new ConcreteBuilder();
            var director = new Director(builder);
            client.ClientCode(director, builder);
        }
    }
}

