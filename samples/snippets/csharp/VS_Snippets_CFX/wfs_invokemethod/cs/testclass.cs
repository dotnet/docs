//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Threading;

namespace Microsoft.Samples.InvokeMethodUsage
{

    public class TestClass
    {
        // to be used for the async sample
        AsyncCallback callback;
        IAsyncResult asyncResult;
        int storedValue;

        public void InstanceMethod()
        {
            Console.WriteLine("....Invoking Instance Method");
        }

        public void InstanceMethod(string param1, int param2)
        {
            Console.WriteLine("....Invoking Instance Method with Parameters");
            Console.WriteLine(string.Format("........param1 (string): {0}", param1));
            Console.WriteLine(string.Format("........param2 (int): {0}", param2));
        }

        public void InstanceMethod(string param1, int param2, params string[] list)
        {
            Console.WriteLine("....Invoking Instance Method with Parameters and Parameter Arrays");
            Console.WriteLine(string.Format("........param1 (string): {0}", param1));
            Console.WriteLine(string.Format("........param2 (int): {0}", param2));
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(string.Format("........param array item {0} (string): {1}", i, list[i]));
            }
        }

        public int InstanceMethodWithResult(int param1, int param2)
        {
            Console.WriteLine("....Invoking Instance Method with Parameters and Result Value");
            Console.WriteLine(string.Format("........param1 (int): {0}", param1));
            Console.WriteLine(string.Format("........param2 (int): {0}", param2));
            return param1 + param2;
        }

        public static void StaticMethod(string param1, int param2)
        {
            Console.WriteLine("....Invoking Static Method with Parameters");
            Console.WriteLine(string.Format("........param1 (string): {0}", param1));
            Console.WriteLine(string.Format("........param2 (int): {0}", param2));
        }

        public void GenericInstanceMethod<T>(T param1)
        {
            Console.WriteLine("....Invoking Generic Instance Method with Parameters");
            Console.WriteLine(string.Format("........typeof T: {0}", typeof(T)));
            Console.WriteLine(string.Format("........param1: {0}", param1));
        }

        public static void GenericStaticMethod<T1, T2>(T1 param1, T2 param2)
        {
            Console.WriteLine("....Invoking Generic Static Method with Parameters");
            Console.WriteLine(string.Format("........typeof T1: {0}", typeof(T1)));
            Console.WriteLine(string.Format("........param1: {0}", param1));
            Console.WriteLine(string.Format("........typeof T2: {0}", typeof(T2)));
            Console.WriteLine(string.Format("........param2: {0}", param2));
        }

        public void InstanceMethod(string param1, int param2, ref string param3)
        {
            Console.WriteLine("....Invoking Instance Method with Parameters");
            Console.WriteLine(string.Format("........param1 (string): {0}", param1));
            Console.WriteLine(string.Format("........param2 (int): {0}", param2));
            Console.WriteLine(string.Format("........out param3 (string): {0}", param3));
            param3 = "reference param changed!";
        }

        public void AsyncMethodSample(string message)
        {
            Console.WriteLine("....Called synchronous sample method with \"{0}\"", message);
            Console.WriteLine("....This method will not be executed, BeginAsyncMethoSample / EndAsyncMethodSample will be executed instead");
        }

        // begin the async operation
        public IAsyncResult BeginAsyncMethodSample(string message, AsyncCallback callback, object asyncState)
        {
            Console.WriteLine("....BeginAsyncMethodSample");
            Console.WriteLine(string.Format("........Message: {0}", message));
            this.callback = callback;
            this.asyncResult = new TestAsyncResult() { AsyncState = asyncState };

            Thread t = new Thread(new ThreadStart(ProcessThread));
            t.Start();            

            return this.asyncResult;
        }

        // do some stuff and invoke the async callback
        public void ProcessThread()
        {
            Console.Write("........Processing ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            
            this.callback(this.asyncResult);
        }

        // end the async operation
        public void EndAsyncMethodSample(IAsyncResult r)
        {
            Console.WriteLine("....EndAsyncMethodSample");
        }

        class TestAsyncResult : IAsyncResult
        {
            public object AsyncState
            {
                get;
                set;
            }

            public WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }

            public bool CompletedSynchronously
            {
                get { return false; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }
        }

        public void StoreValue(int val)
        {
            Console.WriteLine("....Invoking Store Value");
            this.storedValue = val;
        }

        public int GetValue()
        {
            Console.WriteLine("....Invoking Get Value");
            return this.storedValue;
        }
    }
}
