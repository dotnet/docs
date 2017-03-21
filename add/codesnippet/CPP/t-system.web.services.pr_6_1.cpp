public ref class MyHeader: public SoapHeader
{
public:
   String^ MyValue;
};

public ref class MyWebService
{
public:
   MyHeader^ myHeader;

   [WebMethod]
   [SoapHeader("myHeader",
   Direction=SoapHeaderDirection::InOut|SoapHeaderDirection::Fault)]
   void MySoapHeaderReceivingMethod()
   {
      
      // Set myHeader->MyValue to some value.
   }

};
