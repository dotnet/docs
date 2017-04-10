
using namespace System;
using namespace System::Runtime::InteropServices;

// <Snippet1>

[StructLayout(LayoutKind::Explicit)]
public ref class SYSTEM_INFO
{
public:

   [FieldOffset(0)]
   UInt64 OemId;

   [FieldOffset(8)]
   UInt64 PageSize;

   [FieldOffset(24)]
   UInt64 ActiveProcessorMask;

   [FieldOffset(32)]
   UInt64 NumberOfProcessors;

   [FieldOffset(40)]
   UInt64 ProcessorType;
};

// </Snippet1>
