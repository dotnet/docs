using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    public class HttpClient : ClientBase<IRequestChannel>
    {
        public HttpClient( Uri baseUri, bool keepAliveEnabled ) : this( baseUri.ToString(), keepAliveEnabled )
        {
        }
        
        public HttpClient( string baseUri, bool keepAliveEnabled ) : base( HttpClient.CreatePoxBinding( keepAliveEnabled ), 
                                                                           new EndpointAddress( baseUri ) )
        {
        }

        public Message Request( Uri requestUri, string httpMethod )
        {
            Message request = Message.CreateMessage( MessageVersion.None, String.Empty );
            request.Headers.To = requestUri;

            HttpRequestMessageProperty property = new HttpRequestMessageProperty();
            property.Method = httpMethod;
            property.SuppressEntityBody = true;
            request.Properties.Add( HttpRequestMessageProperty.Name, property );
            return this.Channel.Request( request );
        }

        public Message Request( Uri requestUri, string httpMethod, object entityBody )
        {
            Message request = Message.CreateMessage( MessageVersion.None, String.Empty, entityBody );
            request.Headers.To = requestUri;

            HttpRequestMessageProperty property = new HttpRequestMessageProperty();
            property.Method = httpMethod;

            request.Properties.Add( HttpRequestMessageProperty.Name, property );
            return this.Channel.Request( request );
        }

        public Message Get( Uri requestUri )
        {
            return Request( requestUri, "GET" );
        }

        public Message Post( Uri requestUri, object body )
        {
            return Request( requestUri, "POST", body );
        }

        public Message Put( Uri requestUri, object body )
        {
            Message response = Request( requestUri, "PUT", body );
            return response;
        }

        public Message Delete( Uri requestUri )
        {
            return Request( requestUri, "DELETE" );
        }

        public HttpStatusCode GetStatusCode( Message response )
        {
            HttpResponseMessageProperty property = response.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            return property.StatusCode;
        }

        public string GetStatusDescription( Message response )
        {
            HttpResponseMessageProperty property = response.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            return property.StatusDescription;
        }

        public Uri GetLocation( Message response )
        {
            HttpResponseMessageProperty property = response.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;

            string location = property.Headers[ HttpResponseHeader.Location ];

            if( location == null )
                throw new ProtocolException( "Missing Location header" );

            Uri locationUri = null;

            Uri.TryCreate( location, UriKind.Absolute, out locationUri );

            if( locationUri == null )
            {
                Uri.TryCreate( this.Channel.Via, locationUri, out locationUri );
            }

            if( locationUri == null )
            {
                throw new ProtocolException( "Invalid Location: header: " + location );
            }

            return locationUri;
        }

        private static Binding CreatePoxBinding( bool keepAliveEnabled )
        {
            TextMessageEncodingBindingElement encoder = new TextMessageEncodingBindingElement( MessageVersion.None, Encoding.UTF8 );
            // <snippet1>
            HttpTransportBindingElement transport = new HttpTransportBindingElement();
            transport.ManualAddressing = true;
            transport.KeepAliveEnabled = keepAliveEnabled;
	    // </snippet1>		
            return new CustomBinding( new BindingElement[] { encoder, transport } );
        }
    }
}
