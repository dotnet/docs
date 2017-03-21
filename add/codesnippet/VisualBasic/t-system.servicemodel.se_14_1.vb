    Public Class CreditCardSecurityTokenSerializer
        Inherits WSSecurityTokenSerializer

        Public Sub New(ByVal version As SecurityTokenVersion)
            MyBase.New()
        End Sub

        Protected Overrides Function CanReadTokenCore(ByVal reader As XmlReader) As Boolean
            Dim localReader = XmlDictionaryReader.CreateDictionaryReader(reader)
            If reader Is Nothing Then
                Throw New ArgumentNullException("reader")
            End If
            If reader.IsStartElement(Constants.CreditCardTokenName, _
                                     Constants.CreditCardTokenNamespace) Then
                Return True
            End If
            Return MyBase.CanReadTokenCore(reader)
        End Function

        Protected Overrides Function ReadTokenCore(ByVal reader As XmlReader, _
                                                   ByVal tokenResolver As SecurityTokenResolver) As SecurityToken
            If reader Is Nothing Then
                Throw New ArgumentNullException("reader")
            End If
            If reader.IsStartElement(Constants.CreditCardTokenName, _
                                     Constants.CreditCardTokenNamespace) Then

                Dim id = reader.GetAttribute(Constants.Id, _
                                             Constants.WsUtilityNamespace)
                reader.ReadStartElement()

                ' Read the credit card number.
                Dim creditCardNumber = reader.ReadElementString(Constants.CreditCardNumberElementName, _
                                                                Constants.CreditCardTokenNamespace)

                ' Read the expiration date.
                Dim expirationTimeString = reader.ReadElementString(Constants.CreditCardExpirationElementName, _
                                                                    Constants.CreditCardTokenNamespace)
                Dim expirationTime As DateTime = XmlConvert.ToDateTime(expirationTimeString, _
                                                                       XmlDateTimeSerializationMode.Utc)

                ' Read the issuer of the credit card.
                Dim creditCardIssuer = reader.ReadElementString(Constants.CreditCardIssuerElementName, _
                                                                Constants.CreditCardTokenNamespace)
                reader.ReadEndElement()

                Dim cardInfo As New CreditCardInfo(creditCardNumber, _
                                                   creditCardIssuer, _
                                                   expirationTime)

                Return New CreditCardToken(cardInfo, id)
            Else
                Return WSSecurityTokenSerializer.DefaultInstance.ReadToken(reader, _
                                                                           tokenResolver)
            End If
        End Function

        Protected Overrides Function CanWriteTokenCore(ByVal token As SecurityToken) As Boolean
            If TypeOf token Is CreditCardToken Then
                Return True
            Else
                Return MyBase.CanWriteTokenCore(token)
            End If
        End Function

        Protected Overrides Sub WriteTokenCore(ByVal writer As XmlWriter, _
                                               ByVal token As SecurityToken)
            If writer Is Nothing Then
                Throw New ArgumentNullException("writer")
            End If
            If token Is Nothing Then
                Throw New ArgumentNullException("token")
            End If

            Dim c = TryCast(token, CreditCardToken)
            If c IsNot Nothing Then
                With writer
                    .WriteStartElement(Constants.CreditCardTokenPrefix, _
                                       Constants.CreditCardTokenName, _
                                       Constants.CreditCardTokenNamespace)
                    .WriteAttributeString(Constants.WsUtilityPrefix, _
                                          Constants.Id, _
                                          Constants.WsUtilityNamespace, _
                                          token.Id)
                    .WriteElementString(Constants.CreditCardNumberElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        c.CardInfo.CardNumber)
                    .WriteElementString(Constants.CreditCardExpirationElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        XmlConvert.ToString(c.CardInfo.ExpirationDate, _
                                                            XmlDateTimeSerializationMode.Utc))
                    .WriteElementString(Constants.CreditCardIssuerElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        c.CardInfo.CardIssuer)
                    .WriteEndElement()
                    .Flush()
                End With
            Else
                MyBase.WriteTokenCore(writer, token)
            End If
        End Sub

    End Class