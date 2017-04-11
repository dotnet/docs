// System.Web.Services.Description Operation.ParameterOrderString
// System.Web.Services.Description Operation.ParameterOrder

/* The following program demonstrates the 'ParameterOrderString' and
   'ParameterOrder' properties of 'Operation' class. It collects the
   message part names from the input WSDL file and sets to the
   'ParameterOrderString'. It then displays the same using 'ParameterOrder'
   property.
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyOperationClass
{
   public static void Main()
   {
      try
      {
         ServiceDescription myDescription =
         ServiceDescription.Read("Operation_2_Input_CS.wsdl");
         Binding myBinding = new Binding();
         myBinding.Name = "Operation_2_ServiceHttpPost";
         XmlQualifiedName myQualifiedName =
            new XmlQualifiedName("s0:Operation_2_ServiceHttpPost");
         myBinding.Type = myQualifiedName;
         HttpBinding myHttpBinding = new HttpBinding();
         myHttpBinding.Verb="POST";
         // Add the 'HttpBinding' to the 'Binding'.
         myBinding.Extensions.Add(myHttpBinding);
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";
         HttpOperationBinding myHttpOperationBinding = new HttpOperationBinding();
         myHttpOperationBinding.Location="/AddNumbers";
         // Add the 'HttpOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(myHttpOperationBinding);
         InputBinding myInputBinding = new InputBinding();
         MimeContentBinding myPostMimeContentbinding = new MimeContentBinding();
         myPostMimeContentbinding.Type="application/x-www-form-urlencoded";
         myInputBinding.Extensions.Add(myPostMimeContentbinding);
         // Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding;
         OutputBinding myOutputBinding = new OutputBinding();
         MimeXmlBinding myPostMimeXmlbinding = new MimeXmlBinding();
         myPostMimeXmlbinding .Part="Body";
         myOutputBinding.Extensions.Add(myPostMimeXmlbinding);
         // Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding;
         // Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding);
         // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myDescription.Bindings.Add(myBinding);
         Port myPostPort = new Port();
         myPostPort.Name = "Operation_2_ServiceHttpPost";
         myPostPort.Binding = new XmlQualifiedName("s0:Operation_2_ServiceHttpPost");
         HttpAddressBinding myPostAddressBinding = new HttpAddressBinding();
         myPostAddressBinding.Location =
            "http://localhost/Operation_2/Operation_2_Service.cs.asmx";
         // Add the 'HttpAddressBinding' to the 'Port'.
         myPostPort.Extensions.Add(myPostAddressBinding);
         // Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
         myDescription.Services[0].Ports.Add(myPostPort);
         PortType myPostPortType = new PortType();
         myPostPortType.Name = "Operation_2_ServiceHttpPost";
         Operation myPostOperation = new Operation();
         myPostOperation.Name = "AddNumbers";
         OperationMessage myPostOperationInput = (OperationMessage)new OperationInput();
         myPostOperationInput.Message =  new XmlQualifiedName("s0:AddNumbersHttpPostIn");
         OperationMessage myPostOperationOutput = (OperationMessage)new OperationOutput();
         myPostOperationOutput.Message = new XmlQualifiedName("s0:AddNumbersHttpPostout");
         myPostOperation.Messages.Add(myPostOperationInput);
         myPostOperation.Messages.Add(myPostOperationOutput);
         // Add the 'Operation' to 'PortType'.
         myPostPortType.Operations.Add(myPostOperation);
         // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
         myDescription.PortTypes.Add(myPostPortType);
         Message myPostMessage1 = new Message();
         myPostMessage1.Name="AddNumbersHttpPostIn";
         MessagePart myPostMessagePart1 = new MessagePart();
         myPostMessagePart1.Name = "firstnumber";
         myPostMessagePart1.Type = new XmlQualifiedName("s:string");
         MessagePart myPostMessagePart2 = new MessagePart();
         myPostMessagePart2.Name = "secondnumber";
         myPostMessagePart2.Type = new XmlQualifiedName("s:string");
         // Add the 'MessagePart' objects to 'Messages'.
         myPostMessage1.Parts.Add(myPostMessagePart1);
         myPostMessage1.Parts.Add(myPostMessagePart2);
         Message myPostMessage2 = new Message();
         myPostMessage2.Name = "AddNumbersHttpPostout";
         MessagePart myPostMessagePart3 = new MessagePart();
         myPostMessagePart3.Name = "Body";
         myPostMessagePart3.Element = new XmlQualifiedName("s0:int");
         // Add the 'MessagePart' to 'Message'.
         myPostMessage2.Parts.Add(myPostMessagePart3 );
         // Add the 'Message' objects to 'ServiceDescription'.
         myDescription.Messages.Add(myPostMessage1);
         myDescription.Messages.Add(myPostMessage2);
         // Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("Operation_2_Output_CS.wsdl");
         Console.WriteLine(" 'Operation_2_Output_CS.wsdl' file created Successfully");
// <Snippet1>
// <Snippet2>
         string myString = null ;
         Operation myOperation = new Operation();
         myDescription = ServiceDescription.Read("Operation_2_Input_CS.wsdl");
         Message[] myMessage = new Message[ myDescription.Messages.Count ] ;

         // Copy the messages from the service description.
         myDescription.Messages.CopyTo( myMessage, 0 );
         for( int i = 0 ; i < myDescription.Messages.Count; i++ )
         {
            MessagePart[] myMessagePart = 
               new MessagePart[ myMessage[i].Parts.Count ];

            // Copy the message parts into a MessagePart.
            myMessage[i].Parts.CopyTo( myMessagePart, 0 );
            for( int j = 0 ; j < myMessage[i].Parts.Count; j++ )
            {
               myString += myMessagePart[j].Name;
               myString += " " ;
            }
         }
         // Set the ParameterOrderString equal to the list of 
         // message part names.
         myOperation.ParameterOrderString = myString;
         string[] myString1 = myOperation.ParameterOrder;
         int k = 0 ;
         Console.WriteLine("The list of message part names is as follows:");
         while( k<5 )
         {
            Console.WriteLine( myString1[k] );
            k++;
         }
// </Snippet2>
// </Snippet1>
      }
      catch( Exception e )
      {
         Console.WriteLine( "The following Exception is raised : " + e.Message );
      }
   }
}
