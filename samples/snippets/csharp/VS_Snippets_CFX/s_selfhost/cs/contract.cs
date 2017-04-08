//<snippet10>
using System;
// Step 5: Add the using statement for the System.ServiceModel namespace
//<snippet100>
using System.ServiceModel;
//</snippet100>
namespace Microsoft.ServiceModel.Samples
{
  // Step 6: Define a service contract.
//<snippet101>
  [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
  public interface ICalculator
//</snippet101>
  {
    // Step7: Create the method declaration for the contract.
//<snippet102>
    [OperationContract]
    double Add(double n1, double n2);
    [OperationContract]
    double Subtract(double n1, double n2);
    [OperationContract]
    double Multiply(double n1, double n2);
    [OperationContract]
    double Divide(double n1, double n2);
//</snippet102>
  }
}
//</snippet10>
