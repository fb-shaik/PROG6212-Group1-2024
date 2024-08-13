namespace LU1___GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //create some objects (simulate memory allocation)
            for (int i = 0; i < 1000; i++) //loop for 1000 times
            {
               var obj = new SomeObject(i);
                //In each iteration, creates a new instance of SomeObject with the current loop index as its ID
                //Object is cstored in the local variable "obj" which will be out of scope & eligible for the
                //garbage collection after each iteration
            }

            GC.Collect(); // explicitly trigger garbage collection to reclaim memory from objects that are no longer in use
            GC.WaitForPendingFinalizers();
            //Wait for the garbage collector to finalize objects that are eligiable for clean-up

            Console.WriteLine("Garbage collection completed");//Output message

        }
    }

    class SomeObject
        //Define a class called SomeObject that simulates objects being collected
    {
        private readonly int id; //private field that stores the object's id

        public SomeObject(int id) //Constructor that takes an integer parameter to initialize the object's ID
        { 
            this.id = id; //Assign the passed parameter to the private field
        }
    
        //Destructor (finalizer)
        ~SomeObject() 
            //Destructor method, has a ~ that precedes the method name
            //called before the garbage collector to tidy up rescources
        {
            Console.WriteLine($"Object {id} finalized");
        }
    }



}
