using System;
using System.ServiceModel;

[ServiceContractAttribute]
public interface FCADemonstration
{
  // <snippet1>
  [OperationContractAttribute]
  [FaultContractAttribute(typeof(int))]
  int Divide(int arg1, int arg2);
  // </snippet1>
}

public class FCADemoService : FCADemonstration
{
  public int Divide(int arg1, int arg2)
  {
    if (arg1 <= arg2)
    {
      //<snippet2>
      throw new FaultException<int>(4);
      // </snippet2>
    }
    return 0;
  }
}
