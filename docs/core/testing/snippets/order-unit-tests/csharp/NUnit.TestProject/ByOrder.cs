using NUnit.Framework;

namespace NUnit.Project
{
    public class ByOrder
    {
        public static bool Test1Called;
        public static bool Test2ACalled;
        public static bool Test2BCalled;
        public static bool Test3Called;

        [Test, Order(5)]
        public void Test1()
        {
            Test1Called = true;

            Assert.IsFalse(Test2ACalled);
            Assert.IsTrue(Test2BCalled);
            Assert.IsTrue(Test3Called);
        }

        [Test, Order(0)]
        public void Test2B()
        {
            Test2BCalled = true;

            Assert.IsFalse(Test1Called);
            Assert.IsFalse(Test2ACalled);
            Assert.IsTrue(Test3Called);
        }

        [Test]
        public void Test2A()
        {
            Test2ACalled = true;

            Assert.IsTrue(Test1Called);
            Assert.IsTrue(Test2BCalled);
            Assert.IsTrue(Test3Called);
        }

        [Test, Order(-5)]
        public void Test3()
        {
            Test3Called = true;

            Assert.IsFalse(Test1Called);
            Assert.IsFalse(Test2ACalled);
            Assert.IsFalse(Test2BCalled);
        }
    }
}
