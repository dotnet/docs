//C:\_r8_08\code\_SD\WcfApplicationServices\cs\AppSvcClient\Program.cs
#define BigMain
#if (BigMain)
// <snippet999>
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ComponentModel;
using System.Web;
using System.Net;


class MyServiceTst {

    string _Host { get; set; }

    CookieContainer GetCookies(OperationContext oc) {
        HttpResponseMessageProperty httpResponseProperty =
            (HttpResponseMessageProperty)oc.IncomingMessageProperties[HttpResponseMessageProperty.Name];
        if (httpResponseProperty != null) {
            CookieContainer cookieContainer = new CookieContainer();
            string header = httpResponseProperty.Headers[HttpResponseHeader.SetCookie];

            if (header != null) {
                cookieContainer.SetCookies(new Uri(@"http://someuri.tld"), header);
            }
            return cookieContainer;
        }
        return null;
    }

    void SetCookies(OperationContext oc, CookieContainer cookieContainer) {

        HttpRequestMessageProperty httpRequestProperty = null;
        if (oc.OutgoingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name)) {
            httpRequestProperty =
                oc.OutgoingMessageProperties[HttpRequestMessageProperty.Name]
                as HttpRequestMessageProperty;
        }

        if (httpRequestProperty == null) {
            httpRequestProperty = new HttpRequestMessageProperty();
            oc.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name,
                httpRequestProperty);
        }
        httpRequestProperty.Headers.Add(HttpRequestHeader.Cookie,
            cookieContainer.GetCookieHeader(new Uri(@"http://someuri.tld")));
    }


    void GetUserRoles(CookieContainer cookieContainer) {

        string endPtAddr = strEndPtAddr("MyRoleSvcWrap");

        RoleServiceClient roleSvc = new RoleServiceClient(new BasicHttpBinding(),
             new EndpointAddress(endPtAddr));

        using (new OperationContextScope(roleSvc.InnerChannel)) {
            // CookieContainer must be set in order to call GetRolesForCurrentUser().
            // 1638
            SetCookies(OperationContext.Current, cookieContainer);
            string[] roles = roleSvc.GetRolesForCurrentUser();
            if (roles.Length == 0) {
                Console.WriteLine("User does not belong to any role.");
            } else {
                string userRoles = "";
                for (int i = 0; i < roles.Length; i++) {
                    userRoles += roles[i] + " ";
                }
                Console.WriteLine("User's roles: " + userRoles);
            }
        }
    }

    void GetProfileInfo(CookieContainer cookieContainer) {

        string endPtAddr = strEndPtAddr("MyProfileSvcWrap");

        ProfileServiceClient profileSvc = new ProfileServiceClient(new BasicHttpBinding(),
             new EndpointAddress(endPtAddr));

        string[] strProfileProps = new string[] { "FirstName", "LastName", "PhoneNumber" };

        using (new OperationContextScope(profileSvc.InnerChannel)) {
            SetCookies(OperationContext.Current, cookieContainer);
            Dictionary<string, object> profileData =
                profileSvc.GetPropertiesForCurrentUser(strProfileProps, true);

            foreach (string sProp in strProfileProps)
                Console.WriteLine(sProp + ": " + profileData[sProp]);

        }
    }

    public string strEndPtAddr(string service) {

        string endPtAddr = @"http://" + _Host + "/WcfApplicationServices/"
            + service + ".svc?wsdl";

        return endPtAddr;
    }

    public MyServiceTst(string[] args) {

        if (args.Length == 3)
            // The host address was passed in, so that is used.
            _Host = args[2];
        else
            _Host = "localhost:8080";

        string username = args[0];
        string password = args[1];
        string endPtAddr = strEndPtAddr("MyAuthenticationSvcWrap");

        Console.WriteLine("Attempting to connect as username = " + username
            + "\n password length = " + password.Length.ToString()
            + "\n on server " + _Host + "\n"
            + "\n" + "End point address: "  + endPtAddr
        );

        // BasicHttpBinding and endpoint are explicitly passed and ignored
        // in th app.config file.
        BasicHttpBinding binding = new BasicHttpBinding();
        AuthenticationServiceClient authService = new AuthenticationServiceClient(binding,
                                                     new EndpointAddress(endPtAddr));

        CookieContainer cookieContainer;
        string customCredential = "Not used by the default membership provider.";
        
        // Authentication ticket remains valid across sessions.
        bool isPersistent = true;
        bool bLogin = false;

        using (new OperationContextScope(authService.InnerChannel)) {
            try {
                bLogin = authService.Login(username, password,
                                             customCredential, isPersistent);
                cookieContainer = GetCookies(OperationContext.Current);
            } catch (EndpointNotFoundException enfe) {
                Console.WriteLine(enfe.Message);
                if (enfe.InnerException != null && enfe.InnerException.Message != null)
                    Console.WriteLine(enfe.InnerException.Message);
                return;
            }
        }

        if (bLogin) {
            Console.WriteLine("Welcome, " + username + ". You are now logged in.");

            GetUserRoles(cookieContainer);
            GetProfileInfo(cookieContainer);
        } else {
            Console.WriteLine("Credentials could not be validated.");
        }

    }
}

class Program {

    static void Main(string[] args) {

        if (args.Length < 1) {
            Console.WriteLine("Missing command-line arguments: username password [host]");
            return;
        }
        MyServiceTst mst = new MyServiceTst(args);

        Console.WriteLine("Press any key to quit.");
        Console.Read();
    }

}

// </snippet999>
#else

// <snippet99>
using System;
using System.Text;
using System.ServiceModel;

class Program {

    static void Main(string[] args) {

        string username = "joeNA";
        string password = "*(IU89iu";
        bool bLogin = false;

        // BasicHttpBinding and endpoint are provided in app.config file.
        AuthenticationServiceClient authService = new AuthenticationServiceClient();
        string customCredential = "Not used by the default membership provider.";

        // Authentication ticket remains valid across sessions.
        bool isPersistent = true;

        bLogin = authService.Login(username, password, customCredential, isPersistent);

        if (bLogin == true)
            Console.WriteLine("Welcome " + username + ". You have logged in.");
        else
            Console.WriteLine("Unable to login!");
    }
}
// </snippet99>

#endif

/* Installin on Win08
C:\Windows\system32>"C:\Windows\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe" -i
Microsoft(R) Windows Communication Foundation Installation Utility
[Microsoft (R) Windows (R) Communication Foundation, Version 3.0.4506.2060]
Copyright (c) Microsoft Corporation.  All rights reserved.


Installing: Machine.config Section Groups and Handlers
Installing: System.Web Build Provider
Installing: System.Web Compilation Assemblies
Installing: HTTP Handlers
Installing: HTTP Modules
Installing: ListenerAdapter node for protocol net.tcp
Installing: Protocol node for protocol net.tcp
Installing: TransportConfiguration node for protocol net.tcp
Installing: ListenerAdapter node for protocol net.pipe
Installing: Protocol node for protocol net.pipe
Installing: TransportConfiguration node for protocol net.pipe
Installing: ListenerAdapter node for protocol net.msmq
Installing: Protocol node for protocol net.msmq
Installing: TransportConfiguration node for protocol net.msmq
Installing: ListenerAdapter node for protocol msmq.formatname
Installing: Protocol node for protocol msmq.formatname
Installing: TransportConfiguration node for protocol msmq.formatname
Installing: HTTP Modules (WAS)
Installing: HTTP Handlers (WAS)
*/

/* Good posts
http://blogs.msdn.com/kaevans/archive/2008/01/09/what-s-in-a-wcf-binding-and-what-can-my-service-do-right-now.aspx 
 * What's In a WCF Binding, And What Can My Service Do Right Now?
 * 
 * http://msdn.microsoft.com/en-us/library/ms733027.aspx  Windows Communcation Foundation Bindings
 * 
WCF Binding Comparison http://www.pluralsight.com/community/blogs/aaron/archive/2007/03/22/46560.aspx
 * 
 * http://www.wintellect.com/cs/blogs/jsmith/archive/2007/01/19/the-learning-channels.aspx
The following is a rapid-fire description of channels, where they come from, and a code sample to illustrate:
Channels are one of the more complex parts of a WCF application. For those that are new to WCF, a channel is a sink or 
 * a source of a message, and they are largely hidden from the purview of the application developer. In fact, 
 * it is entirely possible (and common) to write a fully functional WCF application and not know a thing about channels. 
 * Even though they are not easily visible at the ServiceModel layer, they are busy behind the scenes sending, receiving,
 * or otherwise mangling messages. 

All channels are not created equal. In the WCF type system, there are channels for each supported transport, 
 * security functionality, and messaging protocol. Furthermore, a channel has at least one shape


*/