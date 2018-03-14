//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------

using System;
using System.IdentityModel.Services;
using System.Web;
using System.Web.Util;

/// <summary>
/// This SampleRequestValidator validates the wresult parameter of the
/// WS-Federation passive protocol by checking for a SignInResponse message
/// in the form post. The SignInResponse message contents are verified later by
/// the WSFederationPassiveAuthenticationModule or the WIF signin controls.
/// </summary>
namespace PassiveFlowSTS
{
    public class SampleRequestValidator : RequestValidator
    {
        protected override bool IsValidRequestString(HttpContext context, string value, RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            validationFailureIndex = 0;

            HttpContextWrapper contextWrapper = new HttpContextWrapper(HttpContext.Current);
            
            if (requestValidationSource == RequestValidationSource.Form && collectionKey.Equals("wresult", StringComparison.Ordinal))
            {
                SignInResponseMessage message = WSFederationMessage.CreateFromFormPost(contextWrapper.Request) as SignInResponseMessage;

                if (message != null)
                {
                    return true;
                }
            }

            return base.IsValidRequestString(context, value, requestValidationSource, collectionKey, out validationFailureIndex);
        }

    }
}
