> [!CAUTION]
> Code Access Security and Partially Trusted Code  
>   
>  The .NET Framework provides a mechanism for the enforcement of varying levels of trust on different code running in the same application called Code Access Security (CAS).  Code Access Security in .NET Framework should not  be used as a mechanism for enforcing security boundaries based on code origination or other identity aspects. We are updating our guidance to reflect that Code Access Security and Security-Transparent Code will not be supported as a security boundary with partially trusted code, especially code of unknown origin. We advise against loading and executing code of unknown origins without putting alternative security measures in place.  
>   
>  This policy applies to all versions of .NET Framework, but does not apply to the .NET Framework included in Silverlight.
