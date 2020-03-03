#using <System.dll>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace PtrToStructureExample
{
    ref class PtrToStructureTester
    {
    public:
        // <snippet1>
        [StructLayout(LayoutKind::Sequential)]
        ref class INNER
        {
        public:
            [MarshalAs(UnmanagedType::ByValTStr,SizeConst=10)]
            String^ field;

            INNER()
            {
                field = "Test";
            }
        };

        [StructLayout(LayoutKind::Sequential)]
        value struct OUTER
        {
        public:
            [MarshalAs(UnmanagedType::ByValTStr,SizeConst=10)]
            String^ field;

            [MarshalAs(UnmanagedType::ByValArray,SizeConst=100)]
            array<Byte>^ inner;
        };

        [DllImport("SomeTestDLL.dll")]
        static void CallTest(OUTER^ outerStructurePointer);

        void static Work()
        {
            OUTER outerStructure;
            array<INNER^>^ innerArray = gcnew array<INNER^>(10);
            INNER^ innerStructure = gcnew INNER;
            int structSize = Marshal::SizeOf(innerStructure);
            int size = innerArray->Length * structSize;
            outerStructure.inner = gcnew array<Byte>(size);

            try
            {
                CallTest(outerStructure);
            }
            catch (SystemException^ ex) 
            {
                Console::WriteLine(ex->Message);
            }

            IntPtr buffer = Marshal::AllocCoTaskMem(structSize * 10);
            Marshal::Copy(outerStructure.inner, 0, buffer, structSize * 10);
            int currentOffset = 0;
            for (int i = 0; i < 10; i++)
            {
                innerArray[i] = safe_cast<INNER^>(Marshal::PtrToStructure(
                    IntPtr(buffer.ToInt32() + currentOffset),
                    INNER::typeid));
                currentOffset += structSize;
            }
            Console::WriteLine(outerStructure.field);
            Marshal::FreeCoTaskMem(buffer);
        }
        // </snippet1>
    };
}

void main()
{
    PtrToStructureExample::PtrToStructureTester::Work();
}
