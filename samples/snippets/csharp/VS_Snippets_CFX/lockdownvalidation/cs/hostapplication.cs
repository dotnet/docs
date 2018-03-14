using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;

using Microsoft.ServiceModel.Samples;

namespace Microsoft.WCF.Documentation
{
  class HostApplication
  {

    static void Main()
    {
      HostApplication app = new HostApplication();
      try
      {
      app.Run();
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex);
        Console.Read();
      }
    }

    private void Run()
    {
      //<snippet1>
      Configuration machine = ConfigurationManager.OpenMachineConfiguration();
      //<snippet5>
      // Register our validator configuration element.
      ExtensionsSection extensions
        = machine.GetSection(@"system.serviceModel/extensions") as ExtensionsSection;
      if (extensions == null)
        throw new Exception("not extensions section.");
      ExtensionElement validator 
        = new ExtensionElement(
          "internetClientValidator", 
          "Microsoft.ServiceModel.Samples.InternetClientValidatorElement, InternetClientValidator, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
        );
      validator.LockItem = true;
      if (extensions.BehaviorExtensions.IndexOf(validator) < 0)
        extensions.BehaviorExtensions.Add(validator);
      //</snippet5>
       
      //<snippet6>
      // Add a new section for our validator and lock it down.
      // Behaviors for client applications must be endpoint behaviors.
      // Behaviors for service applications must be service behaviors.
      CommonBehaviorsSection commonBehaviors
        = machine.GetSection(@"system.serviceModel/commonBehaviors") as CommonBehaviorsSection;
      InternetClientValidatorElement internetValidator = new InternetClientValidatorElement();
      internetValidator.LockItem = true;
      commonBehaviors.EndpointBehaviors.Add(internetValidator);
      //</snippet6>
      //<snippet7>
      // Write to disk.
      machine.SaveAs("newMachine.config");

      // Write our new information.
      SectionInformation cBInfo = commonBehaviors.SectionInformation;
      Console.WriteLine(cBInfo.GetRawXml());
      Console.WriteLine(extensions.SectionInformation.GetRawXml());
      Console.Read();
      //</snippet7>
      //</snippet1>

      /*
    //<snippet4>
    <extensions>
      <behaviorExtensions>
        <add 
          name="internetClientValidator" 
          type="Microsoft.ServiceModel.Samples.InternetClientValidatorElement, InternetClientValidator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
          lockItem="true" />
      </behaviorExtensions>
    </extensions>
    <commonBehaviors>
      <endpointBehaviors>
        <internetClientValidator lockItem="true" />
      </endpointBehaviors>
    </commonBehaviors>
    //</snippet4>

      */
    }
  }
}
