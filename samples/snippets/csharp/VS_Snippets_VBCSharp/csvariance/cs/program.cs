using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //<Snippet1>
            IEnumerable<String> strings = new List<String>();
            IEnumerable<Object> objects = strings;
            //</Snippet1>   

            //<Snippet204>
            Action<object> actObj = x => Console.WriteLine("object: {0}", x);
            Action<string> actStr = x => Console.WriteLine("string: {0}", x);
            // All of the following statements throw exceptions at run time.
            // Action<string> actCombine = actStr + actObj;
            // actStr += actObj;
            // Delegate.Combine(actStr, actObj);
            //</Snippet204>
        

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }

        static void Test()
        {
            //<Snippet102>
            IEnumerable<int> integers = new List<int>();
            // The following statement generates a compiler errror,
            // because int is a value type.
            // IEnumerable<Object> objects = integers;
            //</Snippet102>

            //<Snippet103>
            // The following line generates a compiler error
            // because classes are invariant.
            // List<Object> list = new List<String>();

            // You can use the interface object instead.
            IEnumerable<Object> listObjects = new List<String>();
            //</Snippet103>

        }

        static void SetObject(object o) { } 

        static void Test2()
        {
            //<Snippet205>
            // Assignment compatibility. 
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type. 
            object obj = str;

            // Covariance. 
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument 
            // is assigned to an object instantiated with a less derived type argument. 
            // Assignment compatibility is preserved. 
            IEnumerable<object> objects = strings;

            // Contravariance.           
            // Assume that the following method is in the class: 
            // static void SetObject(object o) { } 
            Action<object> actObject = SetObject;
            // An object that is instantiated with a less derived type argument 
            // is assigned to an object instantiated with a more derived type argument. 
            // Assignment compatibility is reversed. 
            Action<string> actString = actObject;
            //</Snippet205>

            //<Snippet202>
            object[] array = new String[10];
            // The following statement produces a run-time exception.
            // array[0] = 10;
            //</Snippet202>
        }

    }
}

namespace n101
{
    //<Snippet101>
    // Simple hierarchy of classes.
    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.
    class BaseComparer : IEqualityComparer<BaseClass> 
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }
    class Program
    {
        static void Test()
        {
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

            // Implicit conversion of IEqualityComparer<BaseClass> to 
            // IEqualityComparer<DerivedClass>.
            IEqualityComparer<DerivedClass> childComparer = baseComparer;
        }
    }
    //</Snippet101>
 
}
namespace n1
{
    //<Snippet3>
    interface ICovariant<out R>
    {
        R GetSomething();
        // The following statement generates a compiler error.
        // void SetSometing(R sampleArg);

    }
    //</Snippet3>
}

namespace n2
{
    //<Snippet4>
    interface ICovariant<out R>
    {
        void DoSomething(Action<R> callback);
    }
    //</Snippet4>
}

namespace n3
{
    //<Snippet5>
    interface ICovariant<out R>
    {
        // The following statement generates a compiler error
        // because you can use only contravariant or invariant types
        // in generic contstraints.
        // void DoSomething<T>() where T : R;
    }
    //</Snippet5>

    //<Snippet6>
    interface IContravariant<in A>
    {
        void SetSomething(A sampleArg);
        void DoSomething<T>() where T : A;
        // The following statement generates a compiler error.
        // A GetSomething();            
    }
    //</Snippet6>

    //<Snippet7>
    interface IVariant<out R, in A>
    {
        R GetSomething();
        void SetSomething(A sampleArg);
        R GetSetSometings(A sampleArg);
    }
    //</Snippet7>
}

namespace n4
{
    //<Snippet8>
    interface ICovariant<out R>
    {
        R GetSomething();
    }
    class SampleImplementation<R> : ICovariant<R>
    {
        public R GetSomething()
        {
            // Some code.
            return default(R);
        }
    }
    //</Snippet8>

    class Test
    {
        Test()
        {

            //<Snippet9>
            // The interface is covariant.
            ICovariant<Button> ibutton = new SampleImplementation<Button>();
            ICovariant<Object> iobj = ibutton;

            // The class is invariant.
            SampleImplementation<Button> button = new SampleImplementation<Button>();
            // The following statement generates a compiler error
            // because classes are invariant.
            // SampleImplementation<Object> obj = button;
            //</Snippet9>
        }
    }
}

namespace n5
{
    //<Snippet10>
    interface ICovariant<out T> { }
    interface IInvariant<T> : ICovariant<T> { }
    interface IExtCovariant<out T> : ICovariant<T> { }
    //</Snippet10>
}

namespace n6
{
    //<Snippet11>
    interface ICovariant<out T> { }
    interface IContravariant<in T> { }
    interface IInvariant<T> : ICovariant<T>, IContravariant<T> { }
    //</Snippet11>
}

namespace n7
{
    //<Snippet12>
    interface ICovariant<out T> { }
    // The following statement generates a compiler error.
    // interface ICoContraVariant<in T> : ICovariant<T> { }
    //</Snippet12>
}

namespace n8
{
    //<Snippet13>
    // Simple class hierarchy.
    class Animal { }
    class Cat : Animal { }
    class Dog : Animal { }

    // This class introduces ambiguity
    // because IEnumerable<out T> is covariant.
    class Pets : IEnumerable<Cat>, IEnumerable<Dog>
    {
        IEnumerator<Cat> IEnumerable<Cat>.GetEnumerator()
        {
            Console.WriteLine("Cat");
            // Some code.
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Some code.
            return null;
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            Console.WriteLine("Dog");
            // Some code.
            return null;
        }
    }
    class Program
    {
        public static void Test()
        {
            IEnumerable<Animal> pets = new Pets();
            pets.GetEnumerator();
        }
    }
    //</Snippet13>
}

namespace n9
{
    //<Snippet14>
    // Simple hierarchy of classes.
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : Person { }

    class Program
    {
        // The method has a parameter of the IEnumerable<Person> type.
        public static void PrintFullName(IEnumerable<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("Name: {0} {1}",
                person.FirstName, person.LastName);
            }
        }

        public static void Test()
        {
            IEnumerable<Employee> employees = new List<Employee>();

            // You can pass IEnumerable<Employee>, 
            // although the method expects IEnumerable<Person>.

            PrintFullName(employees);

        }
    }
    //</Snippet14>
}

namespace n10
{
    //<Snippet15>
    // Simple hierarchy of classes.
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : Person { }

    // The custom comparer for the Person type
    // with standard implementations of Equals()
    // and GetHashCode() methods.
    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {            
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) ||
                Object.ReferenceEquals(y, null))
                return false;            
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }
        public int GetHashCode(Person person)
        {
            if (Object.ReferenceEquals(person, null)) return 0;
            int hashFirstName = person.FirstName == null
                ? 0 : person.FirstName.GetHashCode();
            int hashLastName = person.LastName.GetHashCode();
            return hashFirstName ^ hashLastName;
        }
    }

    class Program
    {

        public static void Test()
        {
            List<Employee> employees = new List<Employee> {
                   new Employee() {FirstName = "Michael", LastName = "Alexander"},
                   new Employee() {FirstName = "Jeff", LastName = "Price"}
                };

            // You can pass PersonComparer, 
            // which implements IEqualityComparer<Person>,
            // although the method expects IEqualityComparer<Employee>.

            IEnumerable<Employee> noduplicates =
                employees.Distinct<Employee>(new PersonComparer());

            foreach (var employee in noduplicates)
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
        }
    }
    //</Snippet15>
}

namespace n11
{
    //<Snippet16>
    public delegate R DCovariant<out R>();
    //</Snippet16>

    //<Snippet17>
    public delegate void DContravariant<in A>(A a);
    //</Snippet17>

    //<Snippet18>
    public delegate R DVariant<in A, out R>(A a);
    //</Snippet18>

    class Test
    {
        static void Test1()
        {
            //<Snippet19>
            DVariant<String, String> dvariant = (String str) => str + " ";
            dvariant("test");
            //</Snippet19>
        }

    }

}

namespace n104
{
    public class Test1
    {
        //<Snippet104>
        public delegate T SampleGenericDelegate<T>();

        public static void Test()
        {
            SampleGenericDelegate<String> dString = () => " ";

            // You can assign the dObject delegate
            // to the same lambda expression as dString delegate
            // because of the variance support for 
            // matching method signatures with delegate types.
            SampleGenericDelegate<Object> dObject = () => " ";

            // The following statement generates a compiler error
            // because the generic type T is not marked as covariant.
            // SampleGenericDelegate <Object> dObject = dString;

            

        }
        //</Snippet104>
    }
}

namespace n105
{
    public class Test1
    {
        //<Snippet105>
        // Type T is declared covariant by using the out keyword.
        public delegate T SampleGenericDelegate <out T>();
        
        public static void Test()
        {
            SampleGenericDelegate <String> dString = () => " ";
            
            // You can assign delegates to each other,
            // because the type T is declared covariant.
            SampleGenericDelegate <Object> dObject = dString;           
        }
        //</Snippet105>
     }
 }

namespace n106
{
    public class Test1
    {
        //<Snippet106>
        // The type T is covariant.
        public delegate T DVariant<out T>();

        // The type T is invariant.
        public delegate T DInvariant<T>();

        public static void Test()
        {
            int i = 0;
            DInvariant<int> dInt = () => i;
            DVariant<int> dVariantInt = () => i;
            
            // All of the following statements generate a compiler error
            // because type variance in generic parameters is not supported
            // for value types, even if generic type parameters are declared variant.
            // DInvariant<Object> dObject = dInt;
            // DInvariant<long> dLong = dInt;
            // DVariant<Object> dVariantObject = dVariantInt;
            // DVariant<long> dVariantLong = dVariantInt;            
        }
        //</Snippet106>
    }
}


namespace n12
{
    //<Snippet20>
    public class First { }
    public class Second : First { }
    public delegate First SampleDelegate(Second a);
    public delegate R SampleGenericDelegate<A, R>(A a);
    //</Snippet20>

    class Test
    {
        //<Snippet21>
        // Matching signature.
        public static First ASecondRFirst(Second first)
        { return new First(); }

        // The return type is more derived.
        public static Second ASecondRSecond(Second second)
        { return new Second(); }

        // The argument type is less derived.
        public static First AFirstRFirst(First first)
        { return new First(); }

        // The return type is more derived 
        // and the argument type is less derived.
        public static Second AFirstRSecond(First first)
        { return new Second(); }
        //</Snippet21>
   
        //<Snippet22>
        // Assigning a method with a matching signature 
        // to a non-generic delegate. No conversion is necessary.
        SampleDelegate dNonGeneric = ASecondRFirst;
        // Assigning a method with a more derived return type 
        // and less derived argument type to a non-generic delegate.
        // The implicit conversion is used.
        SampleDelegate dNonGenericConversion = AFirstRSecond;

        // Assigning a method with a matching signature to a generic delegate.
        // No conversion is necessary.
        SampleGenericDelegate<Second, First> dGeneric = ASecondRFirst;
        // Assigning a method with a more derived return type 
        // and less derived argument type to a generic delegate.
        // The implicit conversion is used.
        SampleGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;
        //</Snippet22>

    }
}




namespace n13
{
    //<Snippet23>
    // Simple hierarchy of classes.
    public class Person { }
    public class Employee : Person { }
    class Program
    {
        static Employee FindByTitle(String title)
        {
            // This is a stub for a method that returns
            // an employee that has the specified title.
            return new Employee();
        }

        static void Test()
        {
            // Create an instance of the delegate without using variance.
            Func<String, Employee> findEmployee = FindByTitle;

            // The delegate expects a method to return Person,
            // but you can assign it a method that returns Employee.
            Func<String, Person> findPerson = FindByTitle;

            // You can also assign a delegate 
            // that returns a more derived type 
            // to a delegate that returns a less derived type.
            findPerson = findEmployee;

        }
    }
    //</Snippet23>
}

namespace n14
{
    //<Snippet24>
    public class Person { }
    public class Employee : Person { }
    class Program
    {
        static void AddToContacts(Person person)
        {
            // This method adds a Person object
            // to a contact list.
        }

        static void Test()
        {
            // Create an instance of the delegate without using variance.
            Action<Person> addPersonToContacts = AddToContacts;

            // The Action delegate expects 
            // a method that has an Employee parameter,
            // but you can assign it a method that has a Person parameter
            // because Employee derives from Person.
            Action<Employee> addEmployeeToContacts = AddToContacts;

            // You can also assign a delegate 
            // that accepts a less derived parameter to a delegate 
            // that accepts a more derived parameter.
            addEmployeeToContacts = addPersonToContacts;
        }
    }
    //</Snippet24>
}

namespace n15
{
    class Program
    {
        //<Snippet203>
        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }

        static void Test()
        {
            // Covariance. A delegate specifies a return type as object,
            // but you can assign a method that returns a string.
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,
            // but you can assign a method that takes an object.
            Action<string> del2 = SetObject;
        }
        //</Snippet203>
    }
}
