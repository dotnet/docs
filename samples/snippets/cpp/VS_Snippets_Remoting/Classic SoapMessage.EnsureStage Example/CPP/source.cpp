namespace EnsureStageExample
{
   public enum class SoapMessageStage
   {
      BeforeSerialize = 1,
      BeforeDeserialize = 2
   };

   ref class Class1
   {
   public:
      static void main()
      {
         // <Snippet1>
         EnsureStage( (SoapMessageStage)( SoapMessageStage::BeforeSerialize |
            SoapMessageStage::BeforeDeserialize ) );
         // </Snippet1>
      }

   private:
      //This method is a standin for the real method so that the example will compile
      static void EnsureStage( SoapMessageStage /*sms*/ ){}
   };
}
