using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;


namespace cs_inherit
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    // <Snippet1>
    public enum ShapeType
    {
        Square = 0, Circle = 1
    }
    [Table(Name = "Shape")]
    [InheritanceMapping(Code = ShapeType.Square, Type = typeof(Square),
        IsDefault = true)]
    [InheritanceMapping(Code = ShapeType.Circle, Type = typeof(Circle))]

    abstract public class Shape
    {
        [Column(IsDiscriminator = true)]
        public ShapeType ShapeType = 0;
    }

    public class Square : Shape
    {
        [Column]
        public int Side = 0;
    }
    public class Circle : Shape
    {
        [Column]
        public int Radius = 0;
    }
    // </Snippet1>


    // <Snippet2>
    // Unmapped and not queryable.
    class A {  }

    // Mapped and queryable.
    [Table]
    [InheritanceMapping(Code = "B", Type = typeof(B), 
    IsDefault = true)]
    [InheritanceMapping(Code = "D", Type = typeof(D))]
    class B: A {  }

    // Unmapped and not queryable.
    class C: B {  }

    // Mapped and queryable.
    class D: C {  }

    // Unmapped and not queryable.
    class E: D {  }
    // </Snippet2>


}
