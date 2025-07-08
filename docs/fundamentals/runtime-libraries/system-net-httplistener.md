---
title: System.Net.HttpListener class
description: Learn about the System.Net.HttpListener class.
ms.date: 12/31/2023
---
# System.Net.HttpListener class

[!INCLUDE [context](includes/context.md)]

Using the <xref:System.Net.HttpListener> class, you can create a simple HTTP protocol listener that responds to HTTP requests. The listener is active for the lifetime of the <xref:System.Net.HttpListener> object and runs within your application with its permissions.

To use <xref:System.Net.HttpListener>, create a new instance of the class using the <xref:System.Net.HttpListener> constructor and use the <xref:System.Net.HttpListener.Prefixes> property to gain access to the collection that holds the strings that specify which Uniform Resource Identifier (URI) prefixes the <xref:System.Net.HttpListener> should process.

A URI prefix string is composed of a scheme (http or https), a host, an optional port, and an optional path. An example of a complete prefix string is `http://www.contoso.com:8080/customerData/`. Prefixes must end in a forward slash ("/"). The <xref:System.Net.HttpListener> object with the prefix that most closely matches a requested URI responds to the request. Multiple <xref:System.Net.HttpListener> objects cannot add the same prefix; a <xref:System.ComponentModel.Win32Exception> exception is thrown if a <xref:System.Net.HttpListener> adds a prefix that is already in use.

When a port is specified, the host element can be replaced with "\*" to indicate that the <xref:System.Net.HttpListener> accepts requests sent to the port if the requested URI does not match any other prefix. For example, to receive all requests sent to port 8080 when the requested URI is not handled by any <xref:System.Net.HttpListener>, the prefix is *http://\*:8080/*. Similarly, to specify that the <xref:System.Net.HttpListener> accepts all requests sent to a port, replace the host element with the "+" character. For example, *https://+:8080*. The "\*" and "+" characters can be present in prefixes that include paths.

Wildcard subdomains are supported in URI prefixes that are managed by an <xref:System.Net.HttpListener> object. To specify a wildcard subdomain, use the "\*" character as part of the hostname in a URI prefix. For example, *http://\*.foo.com/*. Pass this as the argument to the <xref:System.Net.HttpListenerPrefixCollection.Add%2A> method.

> [!WARNING]
> Top-level wildcard bindings (*http://\*:8080/* and *http://+:8080*) should **not** be used. Top-level wildcard bindings can open up your app to security vulnerabilities. This applies to both strong and weak wildcards. Use explicit host names rather than wildcards. Subdomain wildcard binding (for example, `*.mysub.com`) doesn't have this security risk if you control the entire parent domain (as opposed to `*.com`, which is vulnerable). See [rfc7230 section-5.4](https://tools.ietf.org/html/rfc7230#section-5.4) for more information.

To begin listening for requests from clients, add the URI prefixes to the collection and call the <xref:System.Net.HttpListener.Start%2A> method. <xref:System.Net.HttpListener> offers both synchronous and asynchronous models for processing client requests. Requests and their associated responses are accessed using the <xref:System.Net.HttpListenerContext> object returned by the <xref:System.Net.HttpListener.GetContext%2A> method or its asynchronous counterparts, the <xref:System.Net.HttpListener.BeginGetContext%2A> and <xref:System.Net.HttpListener.EndGetContext%2A> methods.

The synchronous model is appropriate if your application should block while waiting for a client request and if you want to process only one request at a time. Using the synchronous model, call the <xref:System.Net.HttpListener.GetContext%2A> method, which waits for a client to send a request. The method returns an <xref:System.Net.HttpListenerContext> object to you for processing when one occurs.

In the more complex asynchronous model, your application does not block while waiting for requests and each request is processed in its own execution thread. Use the <xref:System.Net.HttpListener.BeginGetContext%2A> method to specify an application-defined method to be called for each incoming request. Within that method, call the <xref:System.Net.HttpListener.EndGetContext%2A> method to obtain the request, process it, and respond.

In either model, incoming requests are accessed using the <xref:System.Net.HttpListenerContext.Request?displayProperty=nameWithType> property and are represented by <xref:System.Net.HttpListenerRequest> objects. Similarly, responses are accessed using the <xref:System.Net.HttpListenerContext.Response?displayProperty=nameWithType> property and are represented by <xref:System.Net.HttpListenerResponse> objects. These objects share some functionality with the <xref:System.Net.HttpWebRequest> and <xref:System.Net.HttpWebResponse> objects, but the latter objects cannot be used in conjunction with <xref:System.Net.HttpListener> because they implement client, not server, behaviors.

An <xref:System.Net.HttpListener> can require client authentication. You can either specify a particular scheme to use for authentication, or you can specify a delegate that determines the scheme to use. You must require some form of authentication to obtain information about the client's identity. For additional information, see the <xref:System.Net.HttpListenerContext.User%2A>, <xref:System.Net.HttpListener.AuthenticationSchemes%2A>, and <xref:System.Net.HttpListener.AuthenticationSchemeSelectorDelegate%2A> properties.

> [!NOTE]
> If you create an <xref:System.Net.HttpListener> using https, you must select a Server Certificate for that listener. Otherwise, requests to this <xref:System.Net.HttpListener> will fail with an unexpected close of the connection.

> [!NOTE]
> You can configure Server Certificates and other listener options by using Network Shell (netsh.exe). See [Network Shell (Netsh)](/windows-server/networking/technologies/netsh/netsh) for more details. The executable began shipping with Windows Server 2008 and Windows Vista.

> [!NOTE]
> If you specify multiple authentication schemes for the <xref:System.Net.HttpListener>, the listener will challenge clients in the following order: `Negotiate`, `NTLM`, `Digest`, and then `Basic`.

## HTTP.sys

The <xref:System.Net.HttpListener> class is built on top of `HTTP.sys`, which is the kernel mode listener that handles all HTTP traffic for Windows.
`HTTP.sys` provides connection management, bandwidth throttling, and web server logging.
Use the [HttpCfg.exe](/windows/win32/http/httpcfg-exe) tool to add SSL certificates.
