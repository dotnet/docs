// <Snippet4>
// Assembly FirstAssembly
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace FirstAssembly
{
    public class InFirstAssembly
    {
        public static void Main()
        {
            FistMethod();
            SecondAssembly.InSecondAssembly.OtherMethod();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void FirstMethod()
        {
            Console.WriteLine("FirstMethod called from: " + Assembly.GetCallingAssembly().FullName);
        }
    }
}

// Assembly SecondAssembly
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SecondAssembly
{
    class InSecondAssembly
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void OtherMethod()
        {
            Console.WriteLine("OtherMehod executing assembly: " + Assembly.GetExecutingAssembly().FullName);
            Console.WriteLine("OtherMethod called from: " + Assembly.GetCallingAssembly().FullName);
        }
    }
}
// The example produces output like the following:
// "FirstMethod called from: FirstAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
// "OtherMethod executing assembly: SecondAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
// "OtherMethod called from: FirstAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
// </Snippet4>
