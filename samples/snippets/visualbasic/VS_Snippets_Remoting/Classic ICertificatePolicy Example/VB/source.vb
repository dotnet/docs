Imports System
Imports System.Net
Imports System.Security.Cryptography.X509Certificates


' <Snippet1>
Public Enum CertificateProblem As Long
    CertEXPIRED                   = 2148204801    ' 0x800B0101
    CertVALIDITYPERIODNESTING     = 2148204802    ' 0x800B0102
    CertROLE                      = 2148204803    ' 0x800B0103
    CertPATHLENCONST              = 2148204804    ' 0x800B0104
    CertCRITICAL                  = 2148204805    ' 0x800B0105
    CertPURPOSE                   = 2148204806    ' 0x800B0106
    CertISSUERCHAINING            = 2148204807    ' 0x800B0107
    CertMALFORMED                 = 2148204808    ' 0x800B0108
    CertUNTRUSTEDROOT             = 2148204809    ' 0x800B0109
    CertCHAINING                  = 2148204810    ' 0x800B010A
    CertREVOKED                   = 2148204812    ' 0x800B010C
    CertUNTRUSTEDTESTROOT         = 2148204813    ' 0x800B010D       
    CertREVOCATION_FAILURE        = 2148204814    ' 0x800B010E
    CertCN_NO_MATCH               = 2148204815    ' 0x800B010F
    CertWRONG_USAGE               = 2148204816    ' 0x800B0110
    CertUNTRUSTEDCA               = 2148204818     ' 0x800B0112
End Enum


Public Class MyCertificateValidation
    Implements ICertificatePolicy
    
    ' Default policy for certificate validation.
    Public Shared DefaultValidate As Boolean = False    
    
    Public Function CheckValidationResult(srvPoint As ServicePoint, _
       cert As X509Certificate, request As WebRequest, problem As Integer) _
       As Boolean Implements ICertificatePolicy.CheckValidationResult
       
        Dim ValidationResult As Boolean = False
        Console.WriteLine(("Certificate Problem with accessing " & _
           request.RequestUri.ToString()))
        Console.Write("Problem code 0x{0:X8},", CInt(problem))
        Console.WriteLine(GetProblemMessage(CType(problem, _
           CertificateProblem)))
        
        ValidationResult = DefaultValidate
        Return ValidationResult
    End Function    
    
    Private Function GetProblemMessage(Problem As CertificateProblem) As String
        Dim ProblemMessage As String = ""
        Dim problemList As New CertificateProblem()
        Dim ProblemCodeName As String = System.Enum.GetName( _
           problemList.GetType(), Problem)
        If Not (ProblemCodeName Is Nothing) Then
            ProblemMessage = ProblemMessage + "-Certificateproblem:" & _
               ProblemCodeName
        Else
            ProblemMessage = "Unknown Certificate Problem"
        End If
        Return ProblemMessage
    End Function
End Class

' </Snippet1>
