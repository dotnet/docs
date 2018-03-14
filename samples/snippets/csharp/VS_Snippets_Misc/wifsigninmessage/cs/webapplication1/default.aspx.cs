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
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Threading;
using System.Web.UI;

namespace PassiveFlowSTS
{
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// Returns whether the user is authenticated or not. 
        /// </summary>
        private bool IsAuthenticatedUser
        {
            get
            {
                return ((Page.User) != null && (Page.User.Identity) != null && (Page.User.Identity.IsAuthenticated));
            }
        }

        // <Snippet1>
        /// <summary>
        /// We perform WS-Federation passive protocol logic in this method and call out to the appropriate request handlers. 
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (IsAuthenticatedUser)
            {
                ClaimsIdentity id = ((ClaimsPrincipal)Thread.CurrentPrincipal).Identities[0];

                // Use the WSFederationMessage.CreateFromUri to parse the request and create a SignInRequestMessage object.
                Uri requestUri = new Uri(Request.Url.AbsoluteUri);
                SignInRequestMessage requestMessage = WSFederationMessage.CreateFromUri(requestUri) as SignInRequestMessage;

                if (requestMessage != null)
                {
                    // Process the sign in request. 
                    SignInResponseMessage responseMessage = ProcessSignInRequest(requestMessage);
                    // Write the response message. 
                    responseMessage.Context = requestMessage.Context;
                    responseMessage.Write(Page.Response.Output);
                    Response.Flush();
                    Response.End();
                }

                string action = Request.QueryString["wa"];
                if (action == "wsignout1.0")
                {
                    FederatedAuthentication.SessionAuthenticationModule.CookieHandler.Delete();
                    string redirectUrl = Request.QueryString["wreply"];
                    if (IsValidReplyUrl(redirectUrl))
                    {
                        Response.Redirect(redirectUrl);
                    }
                }
            }
            // forward to an identity provider
            else
            {
                // <Snippet2>
                string identityProviderUri = Request.QueryString["whr"];
                string action = Request.QueryString["wa"];

                SignInRequestMessage signInRequest = FederatedAuthentication.WSFederationAuthenticationModule.CreateSignInRequest(Guid.NewGuid().ToString(), 
                                                                                                                                  "http://MyAppreturnUrl", 
                                                                                                                                  false);
                signInRequest.Realm = "htp://MyApp.com";
                signInRequest.HomeRealm = identityProviderUri;


                Response.Redirect(signInRequest.RequestUrl);
                // </Snippet2>
            }
        }
        // </Snippet1>

        /// <summary>
        /// Validate the URL received in a wreply query string.
        /// </summary>
        /// <param name="reply">The desired URL.</param>
        /// <returns>true if URL is valid</returns>
        /// <remarks>
        /// Because the wreply directs the STS to redirect to a supplied value, it can
        /// be used as a tool to obscure redirects to malicious sites. For this reason,
        /// the STS should make some attempt to validate the value of reply request.
        /// 
        /// DO NOT use this sample code ‘as is’ in production code.
        /// This is only sample code. A production site would need to validate the request
        /// against known Urls for the current connection.
        /// </remarks>
        bool IsValidReplyUrl(string reply)
        {
            Uri replyUri;
            if (Uri.TryCreate(reply, UriKind.Absolute, out replyUri))
            {
                if (replyUri.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Call the STS to get an appropriate token for a request and build a response.
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns>The <see cref="SignInResponseMessage"/></returns>
        private SignInResponseMessage ProcessSignInRequest(SignInRequestMessage requestMessage)
        {
            // Ensure that the requestMessage has the required wtrealm parameter
            if (String.IsNullOrEmpty(requestMessage.Realm))
            {
                throw new InvalidOperationException("Missing realm");
            }

            SecurityTokenServiceConfiguration stsconfig = new SecurityTokenServiceConfiguration("PassiveFlowSTS");

            // Create our STS backend
            SecurityTokenService sts = new CustomSecurityTokenService(stsconfig);

            // Create the WS-Federation serializer to process the request and create the response
            WSFederationSerializer federationSerializer = new WSFederationSerializer();

            // Create RST from the request
            RequestSecurityToken request = federationSerializer.CreateRequest(requestMessage, new WSTrustSerializationContext());

            // Get RSTR from our STS backend
            RequestSecurityTokenResponse response = sts.Issue((ClaimsPrincipal)Thread.CurrentPrincipal, request);

            // Create Response message from the RSTR
            return new SignInResponseMessage(new Uri(response.ReplyTo),
                    federationSerializer.GetResponseAsString(response, new WSTrustSerializationContext()));
        }
    }
}
