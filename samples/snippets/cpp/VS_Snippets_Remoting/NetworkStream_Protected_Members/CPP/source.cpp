//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

ref class MyNetworkStream_Sub_Class: public NetworkStream
{
public:
   MyNetworkStream_Sub_Class( System::Net::Sockets::Socket^ socket, bool ownsSocket )
      : NetworkStream( socket, ownsSocket )
   {
   }

   property bool IsConnected 
   {
      // You can use the Socket method to examine the underlying Socket.
      bool get()
      {
         return this->Socket->Connected;
      }
   }

   property bool CanCommunicate 
   {
      bool get()
      {
         if ( !this->Readable | !this->Writeable )
         {
            return false;
         }
         else
         {
            return true;
         }
      }
   }
//</Snippet1>

   static void DoSomethingSignificant()
   {
      // Do something significant in here
   }

};

int main()
{
   MyNetworkStream_Sub_Class::DoSomethingSignificant();
}
