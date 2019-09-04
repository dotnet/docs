---
title: gRPC
description: Learn about gRPC and its role in cloud-native applications
author: robvet
ms.date: 09/03/2019
---

# gRPC

So far, we’ve focused on REST-based communication for cloud-native systems. While widely popular, REST does present challenges. One of which is the limited number of available HTTP verbs. This can become challenging when designing REST APIs that support multiple insert and update operations. Equally problematic is the fact that REST transmits raw text over the wire.


REST provides a set of common standards that operate on top of HTTP to help deliver global interoperability between computer systems on the web.  

EST, or REpresentational State Transfer, is an architectural style for providing standards between computer systems on the web, making it easier for systems to communicate with each other.

gRPC, which stands for “Google Remote Procedure Call,” is a binary message-based protocol. It is open source and supported across most popular platforms, including Java, C#, Golang and NodeJS. 

It excels at providing high performance and ease of use, to greatly simplify the construction of all types of distributed systems.

Built on the age-old model of RPC or Remote Procedure Calls, where a client exposes a method that invokes a call to a server and where the method is actually executed. To the developer, it appears as if the method is executed on the client, when in actuality, plumbing is provided that makes a calls to a back-end server. The point-to-point communication, serialization, and exection is handled by the underlying framework.

## Communication considerations

REST message typically are expressed in JSON. While easy to read and write, it is text-based. gRPC works with Protobuf messages which are strongly typed and serailized in a binary format. gRPC is built upon HTTP/2. HTTP/2 protocol is binary. It uses multiplexed streams which means that multiple requests can be sent at the same time without the need to establish TCP connections for each. gRPC lets *stream* information both from the client, server, and bidirectionally. 

RESTFul messages must be serialized and deserialized on both the client and server side. With gRPC, each message is wrapped in a strongly-typed service contract and serialized in a standard Protobuf representation.

At the time of the writing of this book, most browsers have limited support for gRPC. Instead, gRPC is typically used for internal microservice to microservice communication. Figure x.x shows usage.

[Place figure here that shows external calls with HTTP and internal calls with gRPC]

## Protocl Buffers

Using gRPC we define our service once in a .proto file and implement clients and servers in any of gRPC’s supported languages. The complexity of communication between different languages and environments is handled for you by gRPC. We also get all the advantages of working with protocol buffers, including efficient serialization, a simple IDL, and easy interface updating.

Protocol buffers are a flexible, efficient, automated mechanism for serializing structured data – think XML, but smaller, faster, and simpler. You define how you want your data to be structured once, then you can use special generated source code to easily write and read your structured data to and from a variety of data streams and using a variety of languages. You can even update your data structure without breaking deployed programs that are compiled against the "old" format.


	Protocol buffers have many advantages over XML for serializing structured data. Protocol buffers:
		○ are simpler
		○ are 3 to 10 times smaller
		○ are 20 to 100 times faster
		○ are less ambiguous
		○ generate data access classes that are easier to use programmatically
	For example, let's say you want to model a person with a name and an email. In XML, you need to do:
	
	<person>
    <name>John Doe</name>
    <email>jdoe@example.com</email>
  </person>
	while the corresponding protocol buffer message (in protocol buffer text format) is:
	
	# Textual representation of a protocol buffer.
# This is *not* the binary format used on the wire.
person {
  name: "John Doe"
  email: "jdoe@example.com"
}
	When this message is encoded to the protocol buffer binary format (the text format above is just a convenient human-readable representation for debugging and editing), it would probably be 28 bytes long and take around 100-200 nanoseconds to parse. The XML version is at least 69 bytes if you remove whitespace, and would take around 5,000-10,000 nanoseconds to parse.
	Also, manipulating a protocol buffer is much easier:
	  cout << "Name: " << person.name() << endl;
	  cout << "E-mail: " << person.email() << endl;






In the world of cloud-native applications, gRPC could very well play a major role . The performance benefits and ease of development are just too good to pass up. However, make no mistake, REST will still be around for a long time. It still excels for publicly exposed APIs and for backward compatibility reasons. 



>[!div class="step-by-step"]
>[Previous](other-deployment-options.md)
>[Next](front-end-communication.md)
