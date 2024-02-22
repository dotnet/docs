using System;
using System.Windows.Forms;
//using System.Threading;
using System.Drawing;

public delegate int PerformCalculation(int x, int y);
class DelegatesIntro
{

    static int Add(int i, int j)
    {
        return i + j;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static int Calc(PerformCalculation p, int a, int b)
    {
        return p(a, b);
    }
    static void Main()
    {
        var perf = new PerformCalculation(Add);

        Console.WriteLine(Calc(Multiply, 5, 5));
        Console.WriteLine(Calc(Add, 2,2));
        PerformCalculation p = (a,b) => a * b;
        p = (n,b) => n = 5 * n;
        Console.WriteLine(p(6,6));

        perf = Multiply;
        Console.WriteLine(perf(2,3));

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
//-----------------------------------------------------------------------------
class TestStuff
{
    class Temp
    {
        static Temp obj = new Temp();

        //<Snippet1>
        // Declare a delegate.
        delegate void WorkCallback(int x);

        // Define a named method.
        void DoWork(int k) { /* ... */ }

        // Instantiate the delegate using the method as a parameter.
        WorkCallback d = obj.DoWork;
        //</Snippet1>
    }
}

//-----------------------------------------------------------------------------
class TestStuffAgain
{
    //<Snippet13>
    // Declare a delegate.
    delegate void NotifyCallback(string str);

    // Declare a method with the same signature as the delegate.
    static void Notify(string name)
    {
        Console.WriteLine($"Notification received for: {name}");
    }
    //</Snippet13>

    public void DoWork()
    {
        //<Snippet14>
        // Create an instance of the delegate.
        NotifyCallback del1 = new NotifyCallback(Notify);
        //</Snippet14>

        //<Snippet32>
        // C# 2.0 provides a simpler way to declare an instance of NotifyCallback.
        NotifyCallback del2 = Notify;
        //</Snippet32>

        //<Snippet15>
        // Instantiate NotifyCallback by using an anonymous method.
        NotifyCallback del3 = delegate(string name)
            { Console.WriteLine($"Notification received for: {name}"); };
        //</Snippet15>

        //<Snippet31>
        // Instantiate NotifyCallback by using a lambda expression.
        NotifyCallback del4 = name =>  { Console.WriteLine($"Notification received for: {name}"); };
        //</Snippet31>
    }

    //<Snippet20>
    public delegate int PerformCalculation(int x, int y);
    //</Snippet20>

    class DelegateExamples
    {
        //<Snippet21>
        public delegate void Callback(string message);
        //</Snippet21>

        //<Snippet22>
        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        //</Snippet22>

        //<Snippet24>
        public static void MethodWithCallback(int param1, int param2, Callback callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
        //</Snippet24>

        void Method1(string message) { }
        void Method2(string message) { }

        void DoWork()
        {
            //<Snippet23>
            // Instantiate the delegate.
            Callback handler = DelegateMethod;

            // Call the delegate.
            handler("Hello World");
            //</Snippet23>

            //<Snippet25>
            MethodWithCallback(1, 2, handler);
            //</Snippet25>

            //<Snippet27>
            var obj = new MethodClass();
            Callback d1 = obj.Method1;
            Callback d2 = obj.Method2;
            Callback d3 = DelegateMethod;

            //Both types of assignment are valid.
            Callback allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;
            //</Snippet27>

            //<Snippet28>
            //remove Method1
            allMethodsDelegate -= d1;

            // copy AllMethodsDelegate while removing d2
            Callback oneMethodDelegate = allMethodsDelegate - d2;
            //</Snippet28>

            //<Snippet29>
            int invocationCount = d1.GetInvocationList().GetLength(0);
            //</Snippet29>
        }
    }

    //<Snippet26>
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }
    }
    //</Snippet26>

    //<Snippet30>
    delegate void Callback1();
    delegate void Callback2();

    static void method(Callback1 d, Callback2 e, System.Delegate f)
    {
        // Compile-time error.
        //Console.WriteLine(d == e);

        // OK at compile-time. False if the run-time type of f
        // is not the same as that of d.
        Console.WriteLine(d == f);
    }
    //</Snippet30>
}

//-----------------------------------------------------------------------------
namespace WrapNamedMethods1
{
    //<Snippet2>
    // Declare a delegate
    delegate void MultiplyCallback(int i, double j);

    class MathClass
    {
        static void Main()
        {
            MathClass m = new MathClass();

            // Delegate instantiation using "MultiplyNumbers"
            MultiplyCallback d = m.MultiplyNumbers;

            // Invoke the delegate object.
            Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
            for (int i = 1; i <= 5; i++)
            {
                d(i, 2);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Declare the associated method.
        void MultiplyNumbers(int m, double n)
        {
            Console.Write(m * n + " ");
        }
    }
    /* Output:
        Invoking the delegate using 'MultiplyNumbers':
        2 4 6 8 10
    */
    //</Snippet2>
}

//-----------------------------------------------------------------------------
namespace WrapNamedMethods2
{
    //<Snippet3>
    // Declare a delegate
    delegate void Callback();

    class SampleClass
    {
        public void InstanceMethod()
        {
            Console.WriteLine("A message from the instance method.");
        }

        static public void StaticMethod()
        {
            Console.WriteLine("A message from the static method.");
        }
    }

    class TestSampleClass
    {
        static void Main()
        {
            var sc = new SampleClass();

            // Map the delegate to the instance method:
            Callback d = sc.InstanceMethod;
            d();

            // Map to the static method:
            d = SampleClass.StaticMethod;
            d();
        }
    }
    /* Output:
        A message from the instance method.
        A message from the static method.
    */
    //</Snippet3>
}

//-----------------------------------------------------------------------------
namespace WrapCovariance
{
    //<Snippet9>
    class Mammals
    {
    }

    class Dogs : Mammals
    {
    }

    class Program
    {
        // Define the delegate.
        public delegate Mammals HandlerMethod();

        public static Mammals FirstHandler()
        {
            return null;
        }

        public static Dogs SecondHandler()
        {
            return null;
        }

        static void Main()
        {
            HandlerMethod handler1 = FirstHandler;

            // Covariance allows this delegate.
            HandlerMethod handler2 = SecondHandler;
        }
    }
    //</Snippet9>
}

//-----------------------------------------------------------------------------
namespace WrapContravariance
{
    public class Form1 : System.Windows.Forms.Form
    {
        //<Snippet10>
        System.DateTime lastActivity;
        public Form1()
        {
            InitializeComponent();

            lastActivity = new System.DateTime();
            this.textBox1.KeyDown += this.MultiHandler; //works with KeyEventArgs
            this.button1.MouseClick += this.MultiHandler; //works with MouseEventArgs
        }

        // Event handler for any event with an EventArgs or
        // derived class in the second parameter
        private void MultiHandler(object sender, System.EventArgs e)
        {
            lastActivity = System.DateTime.Now;
        }
        //</Snippet10>
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(12, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 266);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }

    //-----------------------------------------------------------------------------
    namespace WrapContravariance
    {
        //<Snippet11>
        using System;

        // Define a custom delegate that has a string parameter and returns void.
        delegate void CustomCallback(string s);

        class TestClass
        {
            // Define two methods that have the same signature as CustomCallback.
            static void Hello(string s)
            {
                Console.WriteLine($"  Hello, {s}!");
            }

            static void Goodbye(string s)
            {
                Console.WriteLine($"  Goodbye, {s}!");
            }

            static void Main()
            {
                // Declare instances of the custom delegate.
                CustomCallback hiDel, byeDel, multiDel, multiMinusHiDel;

                // In this example, you can omit the custom delegate if you
                // want to and use Action<string> instead.
                //Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

                // Initialize the delegate object hiDel that references the
                // method Hello.
                hiDel = Hello;

                // Initialize the delegate object byeDel that references the
                // method Goodbye.
                byeDel = Goodbye;

                // The two delegates, hiDel and byeDel, are combined to
                // form multiDel.
                multiDel = hiDel + byeDel;

                // Remove hiDel from the multicast delegate, leaving byeDel,
                // which calls only the method Goodbye.
                multiMinusHiDel = multiDel - hiDel;

                Console.WriteLine("Invoking delegate hiDel:");
                hiDel("A");
                Console.WriteLine("Invoking delegate byeDel:");
                byeDel("B");
                Console.WriteLine("Invoking delegate multiDel:");
                multiDel("C");
                Console.WriteLine("Invoking delegate multiMinusHiDel:");
                multiMinusHiDel("D");
            }
        }
        /* Output:
        Invoking delegate hiDel:
          Hello, A!
        Invoking delegate byeDel:
          Goodbye, B!
        Invoking delegate multiDel:
          Hello, C!
          Goodbye, C!
        Invoking delegate multiMinusHiDel:
          Goodbye, D!
        */
        //</Snippet11>
    }

    //-----------------------------------------------------------------------------
    namespace WrapDelegateBookstore
    {
        //<Snippet12>
        // A set of classes for handling a bookstore:
        namespace Bookstore
        {
            using System.Collections;

            // Describes a book in the book list:
            public struct Book
            {
                public string Title;        // Title of the book.
                public string Author;       // Author of the book.
                public decimal Price;       // Price of the book.
                public bool Paperback;      // Is it paperback?

                public Book(string title, string author, decimal price, bool paperBack)
                {
                    Title = title;
                    Author = author;
                    Price = price;
                    Paperback = paperBack;
                }
            }

            // Declare a delegate type for processing a book:
            //<Snippet16>
            public delegate void ProcessBookCallback(Book book);
            //</Snippet16>

            // Maintains a book database.
            public class BookDB
            {
                // List of all books in the database:
                ArrayList list = new ArrayList();

                // Add a book to the database:
                public void AddBook(string title, string author, decimal price, bool paperBack)
                {
                    list.Add(new Book(title, author, price, paperBack));
                }

                // Call a passed-in delegate on each paperback book to process it:
                public void ProcessPaperbackBooks(ProcessBookCallback processBook)
                {
                    foreach (Book b in list)
                    {
                        if (b.Paperback)
                            // Calling the delegate:
                            //<Snippet19>
                            processBook(b);
                        //</Snippet19>
                    }
                }
            }
        }

        // Using the Bookstore classes:
        namespace BookTestClient
        {
            using Bookstore;

            // Class to total and average prices of books:
            class PriceTotaller
            {
                int countBooks = 0;
                decimal priceBooks = 0.0m;

                internal void AddBookToTotal(Book book)
                {
                    countBooks += 1;
                    priceBooks += book.Price;
                }

                internal decimal AveragePrice()
                {
                    return priceBooks / countBooks;
                }
            }

            // Class to test the book database:
            class Test
            {
                // Print the title of the book.
                static void PrintTitle(Book b)
                {
                    Console.WriteLine($"   {b.Title}");
                }

                // Execution starts here.
                static void Main()
                {
                    BookDB bookDB = new BookDB();

                    // Initialize the database with some books:
                    AddBooks(bookDB);

                    // Print all the titles of paperbacks:
                    Console.WriteLine("Paperback Book Titles:");

                    // Create a new delegate object associated with the static
                    // method Test.PrintTitle:
                    //<Snippet17>
                    bookDB.ProcessPaperbackBooks(PrintTitle);
                    //</Snippet17>

                    // Get the average price of a paperback by using
                    // a PriceTotaller object:
                    PriceTotaller totaller = new PriceTotaller();

                    // Create a new delegate object associated with the nonstatic
                    // method AddBookToTotal on the object totaller:
                    //<Snippet18>
                    bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);
                    //</Snippet18>

                    Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
                            totaller.AveragePrice());
                }

                // Initialize the book database with some test books:
                static void AddBooks(BookDB bookDB)
                {
                    bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
                    bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
                    bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
                    bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
                }
            }
        }
        /* Output:
        Paperback Book Titles:
           The C Programming Language
           The Unicode Standard 2.0
           Dogbert's Clues for the Clueless
        Average Paperback Book Price: $23.97
        */
        //</Snippet12>
    }
}
