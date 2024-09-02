using System; // Import the System namespace, which includes fundamental classes like Console and IDisposable

class MyResource : IDisposable // Define the MyResource class that implements IDisposable interface for resource management
{
    private readonly string resourceName; // Private readonly field to store the resource name

    public MyResource(string name) // Constructor that takes a string parameter to initialize the resource
    {
        resourceName = name; // Assign the passed parameter to the private field
        Console.WriteLine($"Resource '{resourceName}' acquired."); // Output a message indicating that the resource has been acquired
    }

    // Finalizer (destructor)
    ~MyResource() // Destructor method, called by the garbage collector before reclaiming the object's memory
    {
        Console.WriteLine($"Finalizing resource '{resourceName}'..."); // Output a message indicating that the resource is being finalized
        // Clean up resources (e.g., close file, release connection, etc.)
        // This is the place to release unmanaged resources if not already done in Dispose
    }

    public void Dispose() // Implement IDisposable.Dispose method for explicit resource cleanup
    {
        // Clean up resources explicitly
        Console.WriteLine($"Disposing resource '{resourceName}'..."); // Output a message indicating that the resource is being disposed
        GC.SuppressFinalize(this); // Suppress finalization to avoid the destructor being called again since resources are already cleaned up
    }
}

class Program // Define the main class Program that contains the entry point of the application
{
    static void Main() // Main method is the entry point of the application
    {
        using (var resource = new MyResource("MyFile.txt")) // Create an instance of MyResource within a using statement to ensure proper disposal
        {
            // Use the resource
            Console.WriteLine("Resource in use..."); // Output a message indicating that the resource is currently being used
        } // Dispose() is called automatically here when exiting the using block, ensuring resources are cleaned up properly
    }
}
