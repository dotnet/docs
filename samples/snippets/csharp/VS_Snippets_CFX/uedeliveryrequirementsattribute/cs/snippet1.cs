// <Snippet1>
using System;
using System.ServiceModel;

[ServiceContract]
interface ICalculatorService
{
  [OperationBehavior()]
  int Add(int a, int b);  

  [OperationContract]
  int Subtract(int a, int b);
}

[DeliveryRequirementsAttribute(
  QueuedDeliveryRequirements=QueuedDeliveryRequirementsMode.NotAllowed,
  RequireOrderedDelivery=true
)]
class CalculatorService: ICalculatorService
{
  public int Add(int a, int b)
  {
    Console.WriteLine("Add called.");
    return a + b; 
  }
  
  public int Subtract(int a, int b)
  {
    Console.WriteLine("Subtract called.");
    return a - b;
  }
  
  public int Multiply(int a, int b)
  {
    return a * b;
  }
}
// </Snippet1>
