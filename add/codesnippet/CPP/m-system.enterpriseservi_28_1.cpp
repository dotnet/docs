
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
