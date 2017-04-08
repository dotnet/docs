//<snippet1>
namespace Microsoft.Samples.InstanceDescriptorSample
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;

    //  This sample shows how to support code generation for a custom type 
    //  of object using a type converter and InstanceDescriptor objects.

    //  To use this code, copy it to a file and add the file to a project. 
    //  Then add a component to the project and declare a Triangle field and 
    //  a public property with accessors for the Triangle field on the component.

    //  The Triangle property will be persisted using code generation.

    [TypeConverter(typeof(Triangle.TriangleConverter))]
    public class Triangle
    {
        // Triangle members.
        Point P1;
        Point P2;
        Point P3;

        public Point Point1 {
            get {
                return P1;
            }
            set {
                P1 = value;
            }
        }
        public Point Point2 {
            get 
            {
                return P2;
            }
            set 
            {
                P2 = value;
            }
        }
        public Point Point3 {
            get 
            {
                return P3;
            }
            set 
            {
                P3 = value;
            }
        }

        public Triangle(Point point1,Point point2,Point point3) {
            P1 = point1;
            P2 = point2;
            P3 = point3;
        }

        // A TypeConverter for the Triangle object.  Note that you can make it internal,
        //  private, or any scope you want and the designers will still be able to use
        //  it through the TypeDescriptor object.  This type converter provides the
        //  capability to convert to an InstanceDescriptor.  This object can be used by 
	//  the .NET Framework to generate source code that creates an instance of a 
	//  Triangle object.
        internal class TriangleConverter : TypeConverter
        {
            // This method overrides CanConvertTo from TypeConverter. This is called when someone
            //  wants to convert an instance of Triangle to another type.  Here,
            //  only conversion to an InstanceDescriptor is supported.
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                    return true;
                }

                // Always call the base to see if it can perform the conversion.
                return base.CanConvertTo(context, destinationType);
            }

            // This code performs the actual conversion from a Triangle to an InstanceDescriptor.
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo ci = typeof(Triangle).GetConstructor(new Type[]{typeof(Point),
                                                    typeof(Point),typeof(Point)});
                    Triangle t = (Triangle) value;
                    return new InstanceDescriptor(ci,new object[]{t.Point1,t.Point2,t.Point3});
                }

                // Always call base, even if you can't convert.
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }

    public class TestComponent : System.ComponentModel.Component 
    {
        Triangle myTriangle;

        public TestComponent() {
            myTriangle = new Triangle(
                new Point(5,5),
                new Point(10,10),
                new Point(1,8)
                );
        }

        public Triangle MyTriangle {
            get {
                return myTriangle;
            }
            set {
                myTriangle = value;
            }
        }
    }
}
//</snippet1>
