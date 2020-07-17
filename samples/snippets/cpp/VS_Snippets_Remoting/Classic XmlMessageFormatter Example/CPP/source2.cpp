
// <Snippet2>
using namespace System;
public ref class Order
{
public:
   int itemId;
   int quantity;
   String^ address;
   void ShipItems()
   {
      Console::WriteLine( "Order Placed:" );
      Console::WriteLine( "\tItem ID  : {0}", itemId );
      Console::WriteLine( "\tQuantity : {0}", quantity );
      Console::WriteLine( "\tShip To  : {0}", address );
      
      // Add order to the database.
      /* Insert code here. */
   }

};

// </Snippet2>
