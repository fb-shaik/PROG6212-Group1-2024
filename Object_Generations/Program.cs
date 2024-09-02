namespace Object_Generations // Define a namespace named Object_Generations to organize classes and functions
{
    using System; // Import the System namespace, which includes basic functionalities like Console and GC classes

    class Program // Define the main class Program that contains the entry point of the application
    {
        static void Main() // Main method is the entry point of the application
        {
            // Create some objects (simulating memory allocation)
            for (int i = 0; i < 1000; i++) // Loop 1000 times
            {
                var obj = new SomeObject(i); // In each iteration, create a new instance of SomeObject with the current loop index as its ID
            }

            // Force garbage collection (for demonstration purposes)
            GC.Collect(); // Explicitly trigger garbage collection to reclaim memory from objects that are no longer in use
            GC.WaitForPendingFinalizers(); // Wait for the garbage collector to finalize objects that are eligible for finalization

            Console.WriteLine("Garbage collection completed!"); // Output a message indicating that garbage collection is complete
        }
    }

    class SomeObject // Define a class SomeObject that simulates objects that can be garbage collected
    {
        private readonly int id; // Private field to store the object's ID

        public SomeObject(int id) // Constructor that takes an integer parameter to initialize the object's ID
        {
            this.id = id; // Assign the passed parameter to the private field
        }

        // Destructor (finalizer)
        ~SomeObject() // Destructor method, called by the garbage collector before reclaiming the object's memory
        {
            Console.WriteLine($"Object {id} finalized."); // Output a message indicating that the object with the given ID is being finalized
        }
    }

}
