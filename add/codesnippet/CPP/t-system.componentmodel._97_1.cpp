[LicenseProvider(LicFileLicenseProvider::typeid)]
ref class MyControl: public Control
{
protected:

   // Insert code here.
   ~MyControl()
   {
      /* All components must dispose of the licenses they grant. 
               * Insert code here to dispose of the license. */
   }
};