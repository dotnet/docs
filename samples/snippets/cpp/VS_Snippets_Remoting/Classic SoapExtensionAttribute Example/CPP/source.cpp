

#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Protocols;
using namespace System::IO;

// Class added so sample will compile
public ref class TraceExtension{};

// <Snippet1>
// Create a SoapExtensionAttribute for a SOAP extension that can be
// applied to an XML Web service method.

[AttributeUsage(AttributeTargets::Method)]
public ref class TraceExtensionAttribute: public SoapExtensionAttribute
{
private:
   String^ myFilename;
   int myPriority;

public:

   // Set the name of the log file were SOAP messages will be stored.
   TraceExtensionAttribute()
      : SoapExtensionAttribute()
   {
      myFilename = "C:\\logClient.txt";
   }

   property Type^ ExtensionType 
   {
      // Return the type of 'TraceExtension' class.
      virtual Type^ get() override
      {
         return TraceExtension::typeid;
      }
   }

   property int Priority 
   {
      // User can set priority of the 'SoapExtension'.
      virtual int get() override
      {
         return myPriority;
      }

      virtual void set( int value ) override
      {
         myPriority = value;
      }
   }

   property String^ Filename 
   {
      String^ get()
      {
         return myFilename;
      }

      void set( String^ value )
      {
         myFilename = value;
      }
   }
};
// </Snippet1>
