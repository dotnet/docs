// <Snippet3>
using namespace System;

ref class Object2
{
   private:
      Object^ value;

   public:
      Object2(Object^ value)
      {
         this->value = value;
      }

      virtual String^ ToString() override
      {
         return Object::ToString() + ": " + value->ToString();
      }
};

void main()
{
   Object2^ obj2 = gcnew Object2(L'a');
   Console::WriteLine(obj2->ToString());
 
}
// The example displays the following output:
//       Object2: a
// </Snippet3>
