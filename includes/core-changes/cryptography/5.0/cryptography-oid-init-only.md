### System.Security.Cryptography.Oid is functionally init-only

The <xref:System.Security.Cryptography.Oid?displayProperty=fullName> class, which is used to represent ASN.1 Object Identifier values and their "friendly" names, was previously fully mutable. This mutability was often overlooked or came as a surprise. The property setters now throw a <xref:System.PlatformNotSupportedException> when you attempt to change the value after it's already been assigned.

#### Change description

In previous versions, the property setters on <xref:System.Security.Cryptography.Oid> can be used to change the value of the <xref:System.Security.Cryptography.Oid.FriendlyName> and <xref:System.Security.Cryptography.Oid.Value> properties.

In .NET 5.0 and later versions, the property setters can only be used to initialize the value. Once the property has a value, either from a constructor or a previous call to the property setter, the property setter always throws a <xref:System.PlatformNotSupportedException>.

#### Reason for change

This change enables the reuse of <xref:System.Security.Cryptography.Oid> objects as part of return values in public APIs to reduce object allocation profiles. It avoids the need to create temporary "defensive" copies when <xref:System.Security.Cryptography.Oid> values are used as inputs.

#### Version introduced

5.0 Preview 8

#### Recommended action

Avoid using the <xref:System.Security.Cryptography.Oid> property setters other than for object initialization. To represent a new value, use a new instance instead of changing the value on an existing object.

#### Category

Cryptography

#### Affected APIs

- <xref:System.Security.Cryptography.Oid.FriendlyName?displayProperty=fullName>
- <xref:System.Security.Cryptography.Oid.Value?displayProperty=fullName>

<!--

#### Affected APIs

- `P:System.Security.Cryptography.Oid.FriendlyName`
- `P:System.Security.Cryptography.Oid.Value`

-->
