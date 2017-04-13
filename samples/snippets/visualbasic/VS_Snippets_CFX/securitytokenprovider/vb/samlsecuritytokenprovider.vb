'-----------------------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'-----------------------------------------------------------------------------
' <snippet0>
Imports System

Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens

Imports System.IO

Imports System.ServiceModel.Security

Imports System.Xml


'/ <summary>
'/ class that derives from SecurityTokenProvider and returns a SecurityToken representing a SAML assertion
'/ </summary>

Public Class SamlSecurityTokenProvider
    Inherits SecurityTokenProvider
    '/ <summary>
    '/ The SAML assertion that the SamlSecurityTokenProvider will return as a SecurityToken
    '/ </summary>
    Private assertion As SamlAssertion

    '/ <summary>
    '/ The proof token associated with the SAML assertion
    '/ </summary>
    Private proofToken As SecurityToken


    '/ <summary>
    '/ Constructor
    '/ </summary>
    '/ <param name="assertion">The SAML assertion that the SamlSecurityTokenProvider will return as a SecurityToken</param>
    '/ <param name="proofToken">The proof token associated with the SAML assertion</param>
    Public Sub New(ByVal assertion As SamlAssertion, ByVal proofToken As SecurityToken)
        Me.assertion = assertion
        Me.proofToken = proofToken

    End Sub 'New


    '/ <summary>
    '/ Creates the security token
    '/ </summary>
    '/ <param name="timeout">Maximum amount of time the method is supposed to take. Ignored in this implementation.</param>
    '/ <returns>A SecurityToken corresponding the SAML assertion and proof key specified at construction time</returns>
    ' <snippet1>
    Protected Overrides Function GetTokenCore(ByVal timeout As TimeSpan) As SecurityToken
        ' Create a SamlSecurityToken from the provided assertion
        Dim samlToken As New SamlSecurityToken(assertion)

        ' Create a SecurityTokenSerializer that will be used to serialize the SamlSecurityToken
        Dim ser As New WSSecurityTokenSerializer()

        ' Create a memory stream to write the serialized token into
        ' Use an initial size of 64Kb
        Dim s As New MemoryStream(UInt16.MaxValue)

        ' Create an XmlWriter over the stream
        Dim xw As XmlWriter = XmlWriter.Create(s)

        ' Write the SamlSecurityToken into the stream
        ser.WriteToken(xw, samlToken)

        ' Seek back to the beginning of the stream
        s.Seek(0, SeekOrigin.Begin)

        ' Load the serialized token into a DOM
        Dim dom As New XmlDocument()
        dom.Load(s)

        ' Create a KeyIdentifierClause for the SamlSecurityToken
        Dim samlKeyIdentifierClause As SamlAssertionKeyIdentifierClause = samlToken.CreateKeyIdentifierClause(Of SamlAssertionKeyIdentifierClause)()
        
        ' Return a GenericXmlToken from the XML for the SamlSecurityToken, the proof token, the valid from 
        ' and valid until times from the assertion and the key identifier clause created above            
        Return New GenericXmlSecurityToken(dom.DocumentElement, proofToken, assertion.Conditions.NotBefore, assertion.Conditions.NotOnOrAfter, samlKeyIdentifierClause, samlKeyIdentifierClause, Nothing)

    End Function 'GetTokenCore
End Class 'SamlSecurityTokenProvider 
' </snippet1>
' </snippet0>