Namespace EnsureStageExample
   Class Class1
      
      Public Shared Sub Main()
         ' <Snippet1>
         EnsureStage((SoapMessageStage.BeforeSerialize Or SoapMessageStage.BeforeDeserialize))
      End Sub 'Main
       ' </Snippet1>
      
      'This method is a standin for the real method so that the example will compile
      Private Shared Sub EnsureStage(sms As SoapMessageStage)
      End Sub 'EnsureStage
   End Class 'Class1

   Public Enum SoapMessageStage
      BeforeSerialize = 1
      BeforeDeserialize = 2
   End Enum 'SoapMessageStage
End Namespace 'EnsureStageExample