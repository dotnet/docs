using System;
using System.Collections.Generic;

namespace Snippets
{
    // <ConsoleExtract>
    public class Console
    {
        public static void Write(string fmt, params object[] args) { }
        public static void WriteLine(string fmt, params object[] args) { }
        // ...
    }
    // </ConsoleExtract>
}

namespace TourOfCsharp
{
    // <ColorClassDefinition>
    public class Color
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);
        private byte r, g, b;
        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
    // </ColorClassDefinition>

    // <SquaresClass>
    class Squares
    {
        public static void WriteSquares()
        {
            int i = 0;
            int j;
            while (i < 10)
            {
                j = i * i;
                Console.WriteLine($"{i} x {i} = {j}");
                i = i + 1;
            }
        }
    }
    // </SquaresClass>

    // <EntityClass>
    class Entity
    {
        static int nextSerialNo;
        int serialNo;
        public Entity()
        {
            serialNo = nextSerialNo++;
        }
        public int GetSerialNo()
        {
            return serialNo;
        }
        public static int GetNextSerialNo()
        {
            return nextSerialNo;
        }
        public static void SetNextSerialNo(int value)
        {
            nextSerialNo = value;
        }
    }
    // </EntityClass>

        // <WorkingWithExpressions>
    public abstract class Expression
    {
        public abstract double Evaluate(Dictionary<string, object> vars);
    }
    public class Constant : Expression
    {
        double value;
        public Constant(double value)
        {
            this.value = value;
        }
        public override double Evaluate(Dictionary<string, object> vars)
        {
            return value;
        }
    }
    public class VariableReference : Expression
    {
        string name;
        public VariableReference(string name)
        {
            this.name = name;
        }
        public override double Evaluate(Dictionary<string, object> vars)
        {
            object value = vars[name];
            if (value == null)
            {
                throw new Exception("Unknown variable: " + name);
            }
            return Convert.ToDouble(value);
        }
    }
    public class Operation : Expression
    {
        Expression left;
        char op;
        Expression right;
        public Operation(Expression left, char op, Expression right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }
        public override double Evaluate(Dictionary<string, object> vars)
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }
            throw new Exception("Unknown operator");
        }
    }
    // </WorkingWithExpressions>

    // <Overloading>
    class OverloadingExample
    {
        static void F()
        {
            Console.WriteLine("F()");
        }
        static void F(object x)
        {
            Console.WriteLine("F(object)");
        }
        static void F(int x)
        {
            Console.WriteLine("F(int)");
        }
        static void F(double x)
        {
            Console.WriteLine("F(double)");
        }
        static void F<T>(T x)
        {
            Console.WriteLine("F<T>(T)");
        }
        static void F(double x, double y)
        {
            Console.WriteLine("F(double, double)");
        }
        public static void UsageExample()
        {
            F();            // Invokes F()
            F(1);           // Invokes F(int)
            F(1.0);         // Invokes F(double)
            F("abc");       // Invokes F<string>(string)
            F((double)1);   // Invokes F(double)
            F((object)1);   // Invokes F(object)
            F<int>(1);      // Invokes F<int>(int)
            F(1, 1);        // Invokes F(double, double)
        }
        // </Overloading>
    }

    // <ListExample>
    public class MyList<T>
    {
        // Constant
        const int defaultCapacity = 4;

        // Fields
        T[] items;
        int count;

        // Constructor
        public MyList(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        // Properties
        public int Count => count;

        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < count) value = count;
                if (value != items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(items, 0, newItems, 0, count);
                    items = newItems;
                }
            }
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
                OnChanged();
            }
        }

        // Methods
        public void Add(T item)
        {
            if (count == Capacity) Capacity = count * 2;
            items[count] = item;
            count++;
            OnChanged();
        }
        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public override bool Equals(object other) =>
            Equals(this, other as MyList<T>);

        static bool Equals(MyList<T> a, MyList<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a.count != b.count)
                return false;
            for (int i = 0; i < a.count; i++)
            {
                if (!object.Equals(a.items[i], b.items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Event
        public event EventHandler Changed;

        // Operators
        public static bool operator ==(MyList<T> a, MyList<T> b) =>
            Equals(a, b);

        public static bool operator !=(MyList<T> a, MyList<T> b) =>
            !Equals(a, b);
    }
    // </ListExample>

    // <RespondToEvents>
    class EventExample
    {
        static int changeCount;
        static void ListChanged(object sender, EventArgs e)
        {
            changeCount++;
        }
        public static void Usage()
        {
            MyList<string> names = new MyList<string>();
            names.Changed += new EventHandler(ListChanged);
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(changeCount);		// Outputs "3"
        }
    }
    // </RespondToEvents>


    class ClassesObjects
    {
        // <RefExample>
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public static void SwapExample()
        {
            int i = 1, j = 2;
            Swap(ref i, ref j);
            Console.WriteLine($"{i} {j}");    // Outputs "2 1"
        }
        // </RefExample>

        // <OutExample>
        static void Divide(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }
        public static void OutUsage()
        {
            Divide(10, 3, out int res, out int rem);
            Console.WriteLine($"{res} {rem}");	// Outputs "3 1"
        }
        // </OutExample>

        private static void UseParamArgs()
        {
            // <UseParamsArgs>
            int x, y, z;
            x = 3;
            y = 4;
            z = 5;
            Console.WriteLine("x={0} y={1} z={2}", x, y, z);
            // </UseParamsArgs>
        }


        private static void CompilerParams()
        {
            // <CompilerParams>
            int x = 3, y = 4, z = 5;

            string s = "x={0} y={1} z={2}";
            object[] args = new object[3];
            args[0] = x;
            args[1] = y;
            args[2] = z;
            Console.WriteLine(s, args);
            // </CompilerParams>
        }

        private static void UsingEntity()
        {
            // <UsingEntity>
            Entity.SetNextSerialNo(1000);
            Entity e1 = new Entity();
            Entity e2 = new Entity();
            Console.WriteLine(e1.GetSerialNo());          // Outputs "1000"
            Console.WriteLine(e2.GetSerialNo());          // Outputs "1001"
            Console.WriteLine(Entity.GetNextSerialNo());  // Outputs "1002"
            // </UsingEntity>
        }

        private static void UseExpressions()
        {
            // <UseExpressions>
            Expression e = new Operation(
                new VariableReference("x"),
                '+',
                new Constant(3));
            // </UseExpressions>
        }

        private static void UsingExpressions()
        {
            // <UsingExpressions>
            Expression e = new Operation(
                new VariableReference("x"),
                '*',
                new Operation(
                    new VariableReference("y"),
                    '+',
                    new Constant(2)
                )
            );
            Dictionary<string, object> vars = new Dictionary<string, object>();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(e.Evaluate(vars)); // Outputs "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(e.Evaluate(vars)); // Outputs "16.5"
            // </UsingExpressions>
        }

        private static void ListExampleOne()
        {
            // <CreateLists>
            MyList<string> list1 = new MyList<string>();
            MyList<string> list2 = new MyList<string>(10);
            // </CreateLists>

            // <AccessProperties>
            MyList<string> names = new MyList<string>();
            names.Capacity = 100;   // Invokes set accessor
            int i = names.Count;    // Invokes get accessor
            int j = names.Capacity; // Invokes get accessor
            // </AccessProperties>
        }

        private static void ListAddition()
        {
            // <ListAddition>
            MyList<int> a = new MyList<int>();
            a.Add(1);
            a.Add(2);
            MyList<int> b = new MyList<int>();
            b.Add(1);
            b.Add(2);
            Console.WriteLine(a == b);  // Outputs "True"
            b.Add(3);
            Console.WriteLine(a == b);  // Outputs "False"
            // </ListAddition>
        }

        private static void ListAccess()
        {
            // <ListAccess>
            MyList<string> names = new MyList<string>();
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            for (int i = 0; i < names.Count; i++)
            {
                string s = names[i];
                names[i] = s.ToUpper();
            }
            // </ListAccess>
        }


        public static void Examples()
        {
            SwapExample();
            OutUsage();
            UseParamArgs();
            CompilerParams();
            UsingEntity();
            UseExpressions();
            UsingExpressions();

            ListExampleOne();
            ListAddition();
            EventExample.Usage();
            ListAccess();

        }

    }
}
