
//<Snippet1>
using namespace System;

namespace AttTargsCS
{

   // This attribute is only valid on a class.

   [AttributeUsage(AttributeTargets::Class)]
   public ref class ClassTargetAttribute: public Attribute{};


   // This attribute is only valid on a method.

   [AttributeUsage(AttributeTargets::Method)]
   public ref class MethodTargetAttribute: public Attribute{};


   // This attribute is only valid on a constructor.

   [AttributeUsage(AttributeTargets::Constructor)]
   public ref class ConstructorTargetAttribute: public Attribute{};


   // This attribute is only valid on a field.

   [AttributeUsage(AttributeTargets::Field)]
   public ref class FieldTargetAttribute: public Attribute{};


   // This attribute is valid on a class or a method.

   [AttributeUsage(AttributeTargets::Class|AttributeTargets::Method)]
   public ref class ClassMethodTargetAttribute: public Attribute{};


   // This attribute is valid on any target.

   [AttributeUsage(AttributeTargets::All)]
   public ref class AllTargetsAttribute: public Attribute{};


   [ClassTarget]
   [ClassMethodTarget]
   [AllTargets]
   public ref class TestClassAttribute
   {
   private:

      [ConstructorTarget]
      [AllTargets]
      TestClassAttribute(){}


   public:

      [MethodTarget]
      [ClassMethodTarget]
      [AllTargets]
      void Method1(){}


      [FieldTarget]
      [AllTargets]
      int myInt;
      static void Main(){}

   };

}

//</Snippet1>
