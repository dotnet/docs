using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
using System.Security.Permissions;

namespace ConceptualKnownTypeSamples
{
    public sealed class Test
    {
        private Test() { }
        static void Main()
        {
            SayHello();
        }

        static string SayHello()
        { return "Hello"; }
    }
    // <snippet1>
    [DataContract]
    public class Shape { }

    [DataContract(Name = "Circle")]
    public class CircleType : Shape { }

    [DataContract(Name = "Triangle")]
    public class TriangleType : Shape { }
    // </snippet1>

    // <snippet2>
    [DataContract]
    public class CompanyLogo
    {
        [DataMember]
        private Shape ShapeOfLogo;
        [DataMember]
        private int ColorOfLogo;
    }
    // </snippet2>

    // <snippet3>
    [DataContract]
    [KnownType(typeof(CircleType))]
    [KnownType(typeof(TriangleType))]
    public class CompanyLogo2
    {
        [DataMember]
        private Shape ShapeOfLogo;
        [DataMember]
        private int ColorOfLogo;
    }
    // </snippet3>

    // <snippet4>
    public interface ICustomerInfo
    {
        string ReturnCustomerName();
    }

    [DataContract(Name = "Customer")]
    public class CustomerTypeA : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "no name";
        }
    }

    [DataContract(Name = "Customer")]
    public class CustomerTypeB : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "no name";
        }
    }

    [DataContract]
    [KnownType(typeof(CustomerTypeB))]
    public class PurchaseOrder
    {
        [DataMember]
        ICustomerInfo buyer;

        [DataMember]
        int amount;
    }
    //</snippet4>

    //<snippet5>
    [DataContract]
    public class Book { }

    [DataContract]
    public class Magazine { }

    [DataContract]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Magazine))]
    public class LibraryCatalog
    {
        [DataMember]
        System.Collections.Hashtable theCatalog;
    }
    //</snippet5>

    //<snippet6>
    [DataContract]
    [KnownType(typeof(int[]))]
    public class MathOperationData
    {
        private object numberValue;
        [DataMember]
        public object Numbers
        {
            get { return numberValue; }
            set { numberValue = value; }
        }
        //[DataMember]
        //public Operation Operation;
    }
    //</snippet6>

    public sealed class MathService
    {
        private MathService() { }

        //<snippet7>
        // This is in the service application code:
        static void Run()
        {

            MathOperationData md = new MathOperationData();

            // This will serialize and deserialize successfully because primitive
            // types like int are always known.
            int a = 100;
            md.Numbers = a;

            // This will serialize and deserialize successfully because the array of
            // integers was added to known types.
            int[] b = new int[100];
            md.Numbers = b;

            // This will serialize and deserialize successfully because the generic
            // List<int> is equivalent to int[], which was added to known types.
            List<int> c = new List<int>();
            md.Numbers = c;
            // This will serialize but will not deserialize successfully because
            // ArrayList is a non-generic collection, which is equivalent to
            // an array of type object. To make it succeed, object[]
            // must be added to the known types.
            ArrayList d = new ArrayList();
            md.Numbers = d;
        }
        //</snippet7>
    }

    public class Square { }
    public class Circle { }

    //<snippet8>
    [DataContract]
    [KnownType(typeof(Square))]
    [KnownType(typeof(Circle))]
    public class MyDrawing
    {
        [DataMember]
        private object Shape;
        [DataMember]
        private int Color;
    }

    [DataContract]
    public class DoubleDrawing : MyDrawing
    {
        [DataMember]
        private object additionalShape;
    }
    //</snippet8>

    public abstract class GenericDrawing<T>
    {
    }

    //<snippet9>
    [DataContract]
    public class DrawingRecord<T>
    {
        [DataMember]
        private T theData;
        [DataMember]
        private GenericDrawing<T> theDrawing;
    }
    //</snippet9>

    public class ColorDrawing<T> : GenericDrawing<T>
    { }
    public class BlackAndWhiteDrawing<T> : GenericDrawing<T> { }

    //<snippet10>
    [DataContract]
    [KnownType("GetKnownType")]
    public class DrawingRecord2<T>
    {
        [DataMember]
        private T TheData;
        [DataMember]
        private GenericDrawing<T> TheDrawing;

        private static Type[] GetKnownType()
        {
            Type[] t = new Type[2];
            t[0] = typeof(ColorDrawing<T>);
            t[1] = typeof(BlackAndWhiteDrawing<T>);
            return t;
        }
    }
    //</snippet10>
}
