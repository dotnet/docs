//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using System.Security;

namespace TransparencyWarningsDemo
{

    public class HandleProcessCorruptedStateExceptionClass
    {
        [DllImport("SomeModule.dll")]
        private static extern void NativeCode();

        // CA2139 violation - transparent method attempting to handle a process corrupting exception
        [HandleProcessCorruptedStateExceptions]
        public void HandleCorruptingExceptions()
        {
            try
            {
                NativeCode();
            }
            catch (AccessViolationException) { }
        }
    }

}

//</Snippet1>