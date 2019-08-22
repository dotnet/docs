### X509CertificateClaimSet.FindClaims Considers All claimTypes

|   |   |
|---|---|
|Details|In apps that target the .NET Framework 4.6.1, if an X509 claim set is initialized from a certificate that has multiple DNS entries in its SAN field, the <xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims(System.String,System.String)?displayProperty=name> method attempts to match the claimType argument with all the DNS entries.For apps that target previous versions of the .NET Framework, the <xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims(System.String,System.String)?displayProperty=name> method attempts to match the claimType argument only with the last DNS entry.|
|Suggestion|This change only affects applications targeting the .NET Framework 4.6.1. This change may be disabled (or enabled if targetting pre-4.6.1) with the [DisableMultipleDNSEntries](~/docs/framework/migration-guide/mitigation-x509certificateclaimset-findclaims-method.md#mitigation) compatibility switch.|
|Scope|Minor|
|Version|4.6.1|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims(System.String,System.String)?displayProperty=nameWithType></li></ul>|
