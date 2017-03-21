public ref class StateObject
{
public:
   literal int BUFFER_SIZE = 1024;
   Socket^ workSocket;
   array<Byte>^ buffer;
   StringBuilder^ sb;
   StateObject() : workSocket( nullptr )
   {
      buffer = gcnew array<Byte>(BUFFER_SIZE);
      sb = gcnew StringBuilder;
   }
};