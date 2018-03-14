

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security::Cryptography::X509Certificates;

// <Snippet1>
public enum class CertificateProblem : UInt32
{
   CertEXPIRED = 0x800B0101,
   CertVALIDITYPERIODNESTING = 0x800B0102,
   CertROLE = 0x800B0103,
   CertPATHLENCONST = 0x800B0104,
   CertCRITICAL = 0x800B0105,
   CertPURPOSE = 0x800B0106,
   CertISSUERCHAINING = 0x800B0107,
   CertMALFORMED = 0x800B0108,
   CertUNTRUSTEDROOT = 0x800B0109,
   CertCHAINING = 0x800B010A,
   CertREVOKED = 0x800B010C,
   CertUNTRUSTEDTESTROOT = 0x800B010D,
   CertREVOCATION_FAILURE = 0x800B010E,
   CertCN_NO_MATCH = 0x800B010F,
   CertWRONG_USAGE = 0x800B0110,
   CertUNTRUSTEDCA = 0x800B0112
};

public ref class MyCertificateValidation: public ICertificatePolicy
{
public:

   // Default policy for certificate validation.
   static bool DefaultValidate = false;
   virtual bool CheckValidationResult( ServicePoint^ /*sp*/, X509Certificate^ /*cert*/, WebRequest^ request, int problem )
   {
      bool ValidationResult = false;
      Console::WriteLine( "Certificate Problem with accessing {0}", request->RequestUri );
      Console::Write( "Problem code 0x{0:X8},", (int)problem );
      Console::WriteLine( GetProblemMessage( (CertificateProblem)problem ) );
      ValidationResult = DefaultValidate;
      return ValidationResult;
   }

private:
   String^ GetProblemMessage( CertificateProblem Problem )
   {
      String^ ProblemMessage = "";
      CertificateProblem problemList = CertificateProblem(  );
      String^ ProblemCodeName = Enum::GetName( problemList.GetType(), Problem );
      if ( ProblemCodeName != nullptr )
            ProblemMessage = String::Concat( ProblemMessage, "-Certificateproblem:", ProblemCodeName );
      else
            ProblemMessage = "Unknown Certificate Problem";

      return ProblemMessage;
   }
};
// </Snippet1>
