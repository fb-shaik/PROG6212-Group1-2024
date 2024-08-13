using System;

class Program
{
    static void Main(string[] args)
    {
        // Inform user about the creation of initial set of objects
        Console.WriteLine("Creating generation 0 objects...");
        CreateGenerationObjects();

        // Output the number of times generation 0 has been collected by the garbage collector so far
        Console.WriteLine($"Gen 0 has been collected {GC.CollectionCount(0)} times.");

        // Explicitly trigger garbage collection for Generation 0
        GC.Collect(0);
        Console.WriteLine("Forced GC on Gen 0");
        // Output the updated collection count after manual GC trigger
        Console.WriteLine($"Gen 0 has been collected {GC.CollectionCount(0)} times.");

        // Create additional objects to demonstrate garbage collection across generations
        CreateGenerationObjects();

        // Force garbage collection again to demonstrate movement of objects to Gen 1
        GC.Collect(0);
        Console.WriteLine("Forced second GC on Gen 0");

        // Output how many times Generation 1 has been collected after promoting objects from Gen 0
        Console.WriteLine($"Gen 1 has been collected {GC.CollectionCount(1)} times.");

        // Create a large object, intended to be long-lived and potentially moved to a higher generation quickly
        CreateLongLivedObject();

        // Force garbage collection on Generation 2 to show how it handles long-lived objects
        GC.Collect(2);
        Console.WriteLine("Forced GC on Gen 2");
        // Output collection count for Gen 2, demonstrating less frequent collections due to longer-lived objects
        Console.WriteLine($"Gen 2 has been collected {GC.CollectionCount(2)} times.");
    }

    static void CreateGenerationObjects()
    {
        // Create 1000 objects of 1 KB each to simulate short-lived objects
        // Typically these objects would be collected in the first generation (Gen 0) during garbage collection
        for (int i = 0; i < 1000; i++)
        {
            var obj = new byte[1024]; // Each object is 1 KB
            // Note: obj is local to this loop and thus short-lived, becoming eligible for garbage collection once the loop exits
        }
    }

    static void CreateLongLivedObject()
    {
        // Create a significantly larger object (10 MB) intended to demonstrate handling of long-lived objects
        // Such objects are likely to be promoted to Gen 2 more quickly than smaller, short-lived objects
        var longLivedObj = new byte[1024 * 1024 * 10]; // 10 MB
        Console.WriteLine("Created a long-lived object of 10 MB.");
    }
}
