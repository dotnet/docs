// <Snippet7>
using System;
using System.Deployment.Application;

public class Example
{
   public static void Main()
   {
      Version ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
      Console.WriteLine($"ClickOnce Publish Version: {ver}");
   }
}
// </Snippet7>
