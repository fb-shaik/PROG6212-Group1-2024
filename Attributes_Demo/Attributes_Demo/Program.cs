/*
 * [Obsolete(
   message
    )]

    [Obsolete(
   message,
   iserror
    )]
*/

public class MyClass
{
    [Obsolete("Don't use OldMethod, use NewMethod instead", true)]

    static void OldMethod()
    {
        Console.WriteLine("It is the old method");
    }
    static void NewMethod()
    {
        Console.WriteLine("It is the new method");
    }
    public static void Main()
    {
        OldMethod();
    }
}