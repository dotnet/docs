//<Snippet1>
using System;

namespace AttTargsCS {
    // This attribute is only valid on a class.
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassTargetAttribute : Attribute {
    }

    // This attribute is only valid on a method.
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodTargetAttribute : Attribute {
    }

    // This attribute is only valid on a constructor.
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConstructorTargetAttribute : Attribute {
    }

    // This attribute is only valid on a field.
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldTargetAttribute : Attribute {
    }

    // This attribute is valid on a class or a method.
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class ClassMethodTargetAttribute : Attribute {
    }

    // This attribute is valid on a generic type parameter.
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class GenericParameterTargetAttribute : Attribute {
    }

    // This attribute is valid on any target.
    [AttributeUsage(AttributeTargets.All)]
    public class AllTargetsAttribute : Attribute {
    }

    [ClassTarget]
    [ClassMethodTarget]
    [AllTargets]
    public class TestClassAttribute {
        [ConstructorTarget]
        [AllTargets]
        TestClassAttribute() {
        }

        [MethodTarget]
        [ClassMethodTarget]
        [AllTargets]
        public void Method1() {
        }

        [FieldTarget]
        [AllTargets]
        public int myInt;

        public void GenericMethod<
            [GenericParameterTarget, AllTargets] T>(T x) {
        }

        static void Main(string[] args) {
        }
    }
}
//</Snippet1>