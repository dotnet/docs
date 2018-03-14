//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.ServiceModel.Samples
{
    public enum WseSecurityAssertion
    {
        UsernameOverTransport = 0,
        MutualCertificate10 = 1,
        UsernameForCertificate = 2,
        AnonymousForCertificate = 3,
        MutualCertificate11 = 4,
        Kerberos = 5
    }
}
