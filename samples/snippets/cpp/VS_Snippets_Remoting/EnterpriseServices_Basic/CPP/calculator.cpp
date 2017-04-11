

#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;

// <snippet1>

[assembly:ApplicationName("Calculator")];
[assembly:ApplicationActivation(ActivationOption::Library)];
[assembly:System::Reflection::AssemblyKeyFile("Calculator.snk")];
public ref class Calculator: public ServicedComponent
{
public:
   int Add( int x, int y )
   {
      return (x + y);
   }

};

// </snippet1>
