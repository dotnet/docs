using namespace System;
public ref class Counter: public MarshalByRefObject
{
private:
   int count;

public:
   Counter()
   {
      count = 0;
   }

   property int Count 
   {
      int get()
      {
         return (count)++;
      }
   }
};