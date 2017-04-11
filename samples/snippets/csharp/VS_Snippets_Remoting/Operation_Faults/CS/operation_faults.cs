// System.Web.Services.Description.Operation.Faults

/* The following program demonstrates the 'Faults' property of 'Operation'
   class. It reads from a 'Operation_Faults_Input_CS.wsdl' file removes fault
   binding and operation fault with the name 'ErrorString'. The modified
   ServiceDescriptor is written to 'Operation_Faults_Output_CS.wsdl' file.
*/

using System;
using System.Web.Services.Description;

public class MyOperationClass
{
   public static void Main()
   {
// <Snippet1>
      // Read the 'Operation_Faults_Input_CS.wsdl' file as input.
      ServiceDescription myServiceDescription =
         ServiceDescription.Read("Operation_Faults_Input_CS.wsdl");

      // Get the operation fault collection.
      PortTypeCollection myPortTypeCollection = myServiceDescription.PortTypes;
      PortType myPortType = myPortTypeCollection[0];
      OperationCollection myOperationCollection = myPortType.Operations;

      // Remove the operation fault with the name 'ErrorString'.
      Operation myOperation = myOperationCollection[0];
      OperationFaultCollection myOperationFaultCollection = myOperation.Faults;
      if(myOperationFaultCollection.Contains(myOperationFaultCollection["ErrorString"]))
         myOperationFaultCollection.Remove(myOperationFaultCollection["ErrorString"]);
// </Snippet1>

      // Get the fault binding collection.
      BindingCollection myBindingCollection = myServiceDescription.Bindings;
      Binding myBinding = myBindingCollection[0];
      OperationBindingCollection myOperationBindingCollection = myBinding.Operations;
      // Remove the fault binding with the name 'ErrorString'.
      OperationBinding myOperationBinding = myOperationBindingCollection[0];
      FaultBindingCollection myFaultBindingCollection = myOperationBinding.Faults;
      if(myFaultBindingCollection.Contains(myFaultBindingCollection["ErrorString"]))
         myFaultBindingCollection.Remove(myFaultBindingCollection["ErrorString"]);

      myServiceDescription.Write("Operation_Faults_Output_CS.wsdl");
      Console.WriteLine("WSDL file with name 'Operation_Faults_Output_CS.wsdl' file created Successfully");
   }
}