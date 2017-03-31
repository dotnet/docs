// <snippet1>
using System;
using System.ComponentModel;
using System.Windows.Forms;


// Adds the LicenseProviderAttribute to the control.
[LicenseProvider(typeof(LicFileLicenseProvider))]
public class MyControl : Control 
{
 
   // Creates a new, null license.
   private License license = null;
 
   public MyControl () 
   {
 
      // Adds Validate to the control's constructor.
      license = LicenseManager.Validate(typeof(MyControl), this);
 
      // Insert code to perform other instance creation tasks here.
   }
 
   protected override void Dispose(bool disposing) 
   {
      if(disposing)
      {
         if (license != null) 
         {
            license.Dispose();
            license = null;
         }
      }
   }
 
}
// </snippet1>
