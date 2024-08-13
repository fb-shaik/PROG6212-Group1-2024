//Indexers allow objects to be indexed in the same way as arrays
//This means you can access elements within an object using the array operator []
//Indexers are defined using the 'this' keyword & can take one / more parameters
//These parameters are seen as properties but instead of accessing a single value
// you are able to access multiple values using the index
//Parameters & Return-Type of the indexer can differ
//Indexer help enforce encapsulation of the internal data structure of the class
//Also provides a clean-array like syntax for access of elements

public class Example {
    //private array to hold integer values
    private int[] numbers = new int[10];

    //accessSpecifier dataType this[int index]
    //{get & set}
    public int this[int index] 
        { 
            //get & set to access & retrieve the value at a specified index
            get {return numbers[index];}
            set {numbers[index] = value;}
        }
}

public class Program {
    public static void Main(string[] args) 
    { //create an instance of the Example class above
      Example example = new Example();

        //make of the indexer

        //set the value at the index 0 of the above numbers array to 5 using the indexer
        example[0] = 5;

        //retrieve the value at the index 0 of the above numbers array using the indexer
        int value = example[0];

        //Output message to show the use of the indexer
        Console.WriteLine(value); //expected output: 5 


    
    
    }


}

