    [LicenseProvider(typeof(LicFileLicenseProvider))]
     public class MyControl : Control {
     
        // Insert code here.
     
        protected override void Dispose(bool disposing) {
           /* All components must dispose of the licenses they grant. 
            * Insert code here to dispose of the license. */
        }
     }