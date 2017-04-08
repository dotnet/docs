// <Snippet2>
using System;
using System.ServiceModel;

[ServiceContract]
interface ICalculatorService
{
    [OperationBehavior(TransactionAutoComplete = true)]
    int Add(int a, int b);

    [OperationContract]
    int Subtract(int a, int b);
}

[DeliveryRequirementsAttribute(
  QueuedDeliveryRequirements = QueuedDeliveryRequirementsMode.NotAllowed,
  RequireOrderedDelivery = true,
  TargetContract= typeof(ICalculatorService)
)]
class CalculatorService : ICalculatorService
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
// </Snippet2>