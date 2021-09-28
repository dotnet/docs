namespace MyNamespace
{
    /// <summary>
    /// Enter description here for class X.
    /// ID string generated is "T:MyNamespace.X".
    /// </summary>
    public unsafe class MyClass
    {
        /// <summary>
        /// Enter description here for the first constructor.
        /// ID string generated is "M:MyNamespace.MyClass.#ctor".
        /// </summary>
        public MyClass() { }

        /// <summary>
        /// Enter description here for the second constructor.
        /// ID string generated is "M:MyNamespace.MyClass.#ctor(System.Int32)".
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public MyClass(int i) { }

        /// <summary>
        /// Enter description here for field message.
        /// ID string generated is "F:MyNamespace.MyClass.message".
        /// </summary>
        public string message;

        /// <summary>
        /// Enter description for constant PI.
        /// ID string generated is "F:MyNamespace.MyClass.PI".
        /// </summary>
        public const double PI = 3.14;

        /// <summary>
        /// Enter description for method func.
        /// ID string generated is "M:MyNamespace.MyClass.func".
        /// </summary>
        /// <returns>Describe return value.</returns>
        public int func() { return 1; }

        /// <summary>
        /// Enter description for method someMethod.
        /// ID string generated is "M:MyNamespace.MyClass.someMethod(System.String,System.Int32@,System.Void*)".
        /// </summary>
        /// <param name="str">Describe parameter.</param>
        /// <param name="num">Describe parameter.</param>
        /// <param name="ptr">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int someMethod(string str, ref int nm, void* ptr) { return 1; }

        /// <summary>
        /// Enter description for method anotherMethod.
        /// ID string generated is "M:MyNamespace.MyClass.anotherMethod(System.Int16[],System.Int32[0:,0:])".
        /// </summary>
        /// <param name="array1">Describe parameter.</param>
        /// <param name="array">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int anotherMethod(short[] array1, int[,] array) { return 0; }

        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:MyNamespace.MyClass.op_Addition(MyNamespace.MyClass,MyNamespace.MyClass)".
        /// </summary>
        /// <param name="first">Describe parameter.</param>
        /// <param name="second">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static MyClass operator +(MyClass first, MyClass second) { return first; }

        /// <summary>
        /// Enter description for property.
        /// ID string generated is "P:MyNamespace.MyClass.prop".
        /// </summary>
        public int prop { get { return 1; } set { } }

        /// <summary>
        /// Enter description for event.
        /// ID string generated is "E:MyNamespace.MyClass.OnHappened".
        /// </summary>
        public event Del OnHappened;

        /// <summary>
        /// Enter description for index.
        /// ID string generated is "P:MyNamespace.MyClass.Item(System.String)".
        /// </summary>
        /// <param name="str">Describe parameter.</param>
        /// <returns></returns>
        public int this[string s] { get { return 1; } }

        /// <summary>
        /// Enter description for class Nested.
        /// ID string generated is "T:MyNamespace.MyClass.Nested".
        /// </summary>
        public class Nested { }

        /// <summary>
        /// Enter description for delegate.
        /// ID string generated is "T:MyNamespace.MyClass.Del".
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public delegate void Del(int i);

        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:MyNamespace.MyClass.op_Explicit(MyNamespace.X)~System.Int32".
        /// </summary>
        /// <param name="myParameter">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static explicit operator int(MyClass myParameter) { return 1; }
    }
}
