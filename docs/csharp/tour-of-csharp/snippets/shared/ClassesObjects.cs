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
        public static readonly Color Black = new(0, 0, 0);
        public static readonly Color White = new(255, 255, 255);
        public static readonly Color Red = new(255, 0, 0);
        public static readonly Color Green = new(0, 255, 0);
        public static readonly Color Blue = new(0, 0, 255);
        
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
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
                i++;
            }
        }
    }
    // </SquaresClass>

    // <EntityClass>
    class Entity
    {
        static int s_nextSerialNo;
        int _serialNo;
        
        public Entity()
        {
            _serialNo = s_nextSerialNo++;
        }
        
        public int GetSerialNo()
        {
            return _serialNo;
        }
        
        public static int GetNextSerialNo()
        {
            return s_nextSerialNo;
        }
        
        public static void SetNextSerialNo(int value)
        {
            s_nextSerialNo = value;
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
        double _value;
        
        public Constant(double value)
        {
            _value = value;
        }
        
        public override double Evaluate(Dictionary<string, object> vars)
        {
            return _value;
        }
    }
    
    public class VariableReference : Expression
    {
        string _name;
        
        public VariableReference(string name)
        {
            _name = name;
        }
        
        public override double Evaluate(Dictionary<string, object> vars)
        {
            object value = vars[_name] ?? throw new Exception($"Unknown variable: {_name}");
            return Convert.ToDouble(value);
        }
    }
    
    public class Operation : Expression
    {
        Expression _left;
        char _op;
        Expression _right;
        
        public Operation(Expression left, char op, Expression right)
        {
            _left = left;
            _op = op;
            _right = right;
        }
        
        public override double Evaluate(Dictionary<string, object> vars)
        {
            double x = _left.Evaluate(vars);
            double y = _right.Evaluate(vars);
            switch (_op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
                
                default: throw new Exception("Unknown operator");
            }
        }
    }
    // </WorkingWithExpressions>

    // <Overloading>
    class OverloadingExample
    {
        static void F() => Console.WriteLine("F()");
        static void F(object x) => Console.WriteLine("F(object)");
        static void F(int x) => Console.WriteLine("F(int)");
        static void F(double x) => Console.WriteLine("F(double)");
        static void F<T>(T x) => Console.WriteLine("F<T>(T)");            
        static void F(double x, double y) => Console.WriteLine("F(double, double)");
        
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
    }
    // </Overloading>

    // <ListExample>
    public class MyList<T>
    {
        const int DefaultCapacity = 4;

        T[] _items;
        int _count;

        public MyList(int capacity = DefaultCapacity)
        {
            _items = new T[capacity];
        }

        public int Count => _count;

        public int Capacity
        {
            get =>  _items.Length;
            set
            {
                if (value < _count) value = _count;
                if (value != _items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(_items, 0, newItems, 0, _count);
                    _items = newItems;
                }
            }
        }

        public T this[int index]
        {
            get => _items[index];
            set
            {
                _items[index] = value;
                OnChanged();
            }
        }

        public void Add(T item)
        {
            if (_count == Capacity) Capacity = _count * 2;
            _items[_count] = item;
            _count++;
            OnChanged();
        }
        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public override bool Equals(object other) =>
            Equals(this, other as MyList<T>);

        static bool Equals(MyList<T> a, MyList<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a._count != b._count)
                return false;
            for (int i = 0; i < a._count; i++)
            {
                if (!object.Equals(a._items[i], b._items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public event EventHandler Changed;

        public static bool operator ==(MyList<T> a, MyList<T> b) =>
            Equals(a, b);

        public static bool operator !=(MyList<T> a, MyList<T> b) =>
            !Equals(a, b);
    }
    // </ListExample>

    // <RespondToEvents>
    class EventExample
    {
        static int s_changeCount;
        
        static void ListChanged(object sender, EventArgs e)
        {
            s_changeCount++;
        }
        
        public static void Usage()
        {
            var names = new MyList<string>();
            names.Changed += new EventHandler(ListChanged);
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(s_changeCount); // "3"
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
            Console.WriteLine($"{i} {j}");    // "2 1"
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
            Console.WriteLine($"{res} {rem}");	// "3 1"
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
            Entity e1 = new();
            Entity e2 = new();
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
            Dictionary<string, object> vars = new();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(e.Evaluate(vars)); // "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(e.Evaluate(vars)); // "16.5"
            // </UsingExpressions>
        }

        private static void ListExampleOne()
        {
            // <CreateLists>
            MyList<string> list1 = new();
            MyList<string> list2 = new(10);
            // </CreateLists>

            // <AccessProperties>
            MyList<string> names = new();
            names.Capacity = 100;   // Invokes set accessor
            int i = names.Count;    // Invokes get accessor
            int j = names.Capacity; // Invokes get accessor
            // </AccessProperties>
        }

        private static void ListAddition()
        {
            // <ListAddition>
            MyList<int> a = new();
            a.Add(1);
            a.Add(2);
            MyList<int> b = new();
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
            MyList<string> names = new();
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
