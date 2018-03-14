using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;


// <Snippet1>
 public  enum    CertificateProblem  : long
 {
         CertEXPIRED                   = 0x800B0101,
         CertVALIDITYPERIODNESTING     = 0x800B0102,
         CertROLE                      = 0x800B0103,
         CertPATHLENCONST              = 0x800B0104,
         CertCRITICAL                  = 0x800B0105,
         CertPURPOSE                   = 0x800B0106,
         CertISSUERCHAINING            = 0x800B0107,
         CertMALFORMED                 = 0x800B0108,
         CertUNTRUSTEDROOT             = 0x800B0109,
         CertCHAINING                  = 0x800B010A,
         CertREVOKED                   = 0x800B010C,
         CertUNTRUSTEDTESTROOT         = 0x800B010D,
         CertREVOCATION_FAILURE        = 0x800B010E,
         CertCN_NO_MATCH               = 0x800B010F,
         CertWRONG_USAGE               = 0x800B0110,
         CertUNTRUSTEDCA               = 0x800B0112
 }
 
 public class MyCertificateValidation : ICertificatePolicy
 {
     // Default policy for certificate validation.
     public static bool DefaultValidate = false; 
 
     public bool CheckValidationResult(ServicePoint sp, X509Certificate cert,
        WebRequest request, int problem)
     {        
         bool ValidationResult=false;
         Console.WriteLine("Certificate Problem with accessing " +
            request.RequestUri);
         Console.Write("Problem code 0x{0:X8},",(int)problem);
         Console.WriteLine(GetProblemMessage((CertificateProblem)problem));
 
         ValidationResult = DefaultValidate;
         return ValidationResult; 
     }
     
     private String GetProblemMessage(CertificateProblem Problem)
     {
         String ProblemMessage = "";
         CertificateProblem problemList = new CertificateProblem();
         String ProblemCodeName = Enum.GetName(problemList.GetType(),Problem);
         if(ProblemCodeName != null)
            ProblemMessage = ProblemMessage + "-Certificateproblem:" +
               ProblemCodeName;
         else
            ProblemMessage = "Unknown Certificate Problem";
         return ProblemMessage;
      }
 }
    
// </Snippet1>
