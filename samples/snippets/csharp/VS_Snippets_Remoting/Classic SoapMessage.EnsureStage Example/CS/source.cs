namespace EnsureStageExample
{
   class Class1
   {
      public static void Main()
      {
         // <Snippet1>
         EnsureStage(SoapMessageStage.BeforeSerialize | SoapMessageStage.BeforeDeserialize);
         // </Snippet1>
      }

      //This method is a standin for the real method so that the example will compile
      private static void EnsureStage(SoapMessageStage sms)
      {
      }

   }
   

   public enum SoapMessageStage
   {
      BeforeSerialize = 1,
      BeforeDeserialize = 2
   }
}