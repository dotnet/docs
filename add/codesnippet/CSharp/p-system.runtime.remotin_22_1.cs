
      public override IMessage Invoke(IMessage myIMessage)
      {
         Console.WriteLine("MyProxy.Invoke Start");
         Console.WriteLine("");
         ReturnMessage myReturnMessage = null;
         
         if (myIMessage is IMethodCallMessage)
         {
            Console.WriteLine("Message is of type 'IMethodCallMessage'.");
            Console.WriteLine("");

            IMethodCallMessage myIMethodCallMessage;
            myIMethodCallMessage=(IMethodCallMessage)myIMessage;
            Console.WriteLine("InArgCount is  : " + 
                              myIMethodCallMessage.InArgCount.ToString());
         
            foreach (object myObj in myIMethodCallMessage.InArgs)
            {
               Console.WriteLine("InArgs is : " + myObj.ToString());
            }

            for(int i=0; i<myIMethodCallMessage.InArgCount; i++)
            {
               Console.WriteLine("GetArgName(" +i.ToString() +") is : " + 
                                       myIMethodCallMessage.GetArgName(i));
               Console.WriteLine("GetInArg("+i.ToString() +") is : " +
                              myIMethodCallMessage.GetInArg(i).ToString());
            }
            Console.WriteLine("");
         }
         else if (myIMessage is IMethodReturnMessage)
            Console.WriteLine("Message is of type 'IMethodReturnMessage'.");
                  
         // Build Return Message
         myReturnMessage = new ReturnMessage(5,null,0,null,
                                       (IMethodCallMessage)myIMessage);
      
         Console.WriteLine("MyProxy.Invoke - Finish");
         return myReturnMessage;
      }


   }
  
   
   // The class used to obtain Metadata.
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyMarshalByRefClass : MarshalByRefObject
   {
      public int MyMethod(string str, double dbl, int i)
      {
         Console.WriteLine("MyMarshalByRefClass.MyMethod {0} {1} {2}", str, dbl, i);
         return 0;
      }
   }