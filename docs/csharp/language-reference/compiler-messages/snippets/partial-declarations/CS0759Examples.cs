using System;

namespace CS0759Examples
{
    // <IncorrectExample>
    // This will cause CS0759: No defining declaration found for implementing declaration of partial method
    // Uncomment the class below to see the CS0759 error:
    /*
    public partial class ExampleClass
    {
        // ERROR: This is an implementing declaration without a corresponding defining declaration
        partial void MyMethod() // CS0759
        {
            Console.WriteLine("Implementation without definition");
        }
    }
    */
    // </IncorrectExample>

    // <CorrectExample>
    // Correct way: Provide both the defining declaration and implementing declaration
    public partial class CorrectExampleClass
    {
        // Defining declaration (signature without body)
        partial void MyMethod();
    }

    public partial class CorrectExampleClass
    {
        // Implementing declaration (signature with body)
        partial void MyMethod()
        {
            Console.WriteLine("This works correctly");
        }
    }
    // </CorrectExample>

    // <AlternativeCorrect>
    // Alternative correct approach: defining and implementing in same partial class
    public partial class AlternativeExampleClass
    {
        // Defining declaration
        partial void MyMethod();
        
        // Implementing declaration in same partial class section
        partial void MyMethod()
        {
            Console.WriteLine("This also works correctly");
        }
    }
    // </AlternativeCorrect>
}