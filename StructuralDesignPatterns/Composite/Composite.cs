using System;
using System.Collections.Generic;

// Use when the core model of the app can be represented as tree
public interface IComponent
{
    public void Execute();

    public void Add(IComponent component);

    public void Remove(IComponent component);

    public List<IComponent> GetComponents();

    public bool IsComposite();

}

public class Composite : IComponent
{
    List<IComponent> Components = new List<IComponent>();

    public void Execute()
    {
        Console.Write("Branch(");
        for (int i = 0; i < this.Components.Count; ++i)
        {
            var component = this.Components[i];
            component.Execute();
            if (i != this.Components.Count - 1)
                Console.Write("+");
        }
        Console.Write(")");
    }

    public void Add(IComponent component)
    {
        this.Components.Add(component);
    }

    public void Remove(IComponent component)
    {
        this.Components.Remove(component);
    }

    public List<IComponent> GetComponents()
    {
        return this.Components;
    }

    public bool IsComposite()
    {
        return true;
    }
}

public class Leaf : IComponent
{
    public void Execute()
    {
        Console.Write("LEAF");
    }

    public void Add(IComponent component)
    {
        throw new NotImplementedException();
    }

    public void Remove(IComponent component)
    {
        throw new NotImplementedException();
    }

    public List<IComponent> GetComponents()
    {
        throw new NotImplementedException();
    }

    public bool IsComposite()
    {
        return false;
    }
}

public class Program
{
    public class Client
    {
        public void ClientCode(IComponent leaf)
        {
            Console.Write("RESULT: ");
            leaf.Execute();
        }

        public void ClientCode(IComponent component1, IComponent component2)
        {
            if (component1.IsComposite())
                component1.Add(component2);

            Console.Write("RESULT: ");
            component1.Execute();

            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        var client = new Client();

        IComponent leaf = new Leaf();
        Console.WriteLine("Client: I get a simple component:");
        client.ClientCode(leaf);
        Console.WriteLine("\n");

        Composite tree = new Composite();
        Composite branch1 = new Composite();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());

        Composite branch2 = new Composite();
        branch2.Add(new Leaf());

        tree.Add(branch1);
        tree.Add(branch2);
        Console.WriteLine("Client: Now I get a composite tree:");
        client.ClientCode(tree);
        Console.WriteLine();
        Console.WriteLine("Client: I can merge two components without checking their classes");
        client.ClientCode(tree, leaf);
    }
}