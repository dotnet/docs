'****************************************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        '<Snippet1>
        ' Variable product is an instance of a simple anonymous type.
        Dim product = New With {Key .Name = "paperclips", .Price = 1.29}
        '</Snippet1>

        Dim products = listProducts()
        '<Snippet2>
        Dim namePriceQuery = From prod In products
                             Select prod.Name, prod.Price
        '</Snippet2>

        '<Snippet3>
        Dim nameQuantityQuery = From prod In products
                                Select prod.Name, prod.OnHand
        '</Snippet3>

        '<Snippet4>
        ' Variable product1 is an instance of a simple anonymous type.
        Dim product1 = New With {.Name = "paperclips", .Price = 1.29}
        ' -or-
        ' product2 is an instance of an anonymous type with key properties.
        Dim product2 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        '</Snippet4>

        '<Snippet5>
        ' Variable product3 is an instance of a class named Product.
        Dim product3 = New Product With {.Name = "paperclips", .Price = 1.29}
        '</Snippet5>

        '<Snippet6>
        ' prod1 and prod2 have no key values.
        Dim prod1 = New With {.Name = "paperclips", .Price = 1.29}
        Dim prod2 = New With {.Name = "paperclips", .Price = 1.29}

        ' The following line displays False, because prod1 and prod2 have no
        ' key properties.
        Console.WriteLine(prod1.Equals(prod2))

        ' The following statement displays True because prod1 is equal to itself.
        Console.WriteLine(prod1.Equals(prod1))
        '</Snippet6>

        '<Snippet7>
        Dim prod3 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim prod4 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        ' The following line displays True, because prod3 and prod4 are
        ' instances of the same anonymous type, and the values of their
        ' key properties are equal.
        Console.WriteLine(prod3.Equals(prod4))

        Dim prod5 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim prod6 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 423}
        ' The following line displays False, because prod5 and prod6 do not 
        ' have the same properties.
        Console.WriteLine(prod5.Equals(prod6))

        Dim prod7 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 24}
        Dim prod8 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 423}
        ' The following line displays True, because prod7 and prod8 are
        ' instances of the same anonymous type, and the values of their
        ' key properties are equal. The equality check does not compare the
        ' values of the non-key field.
        Console.WriteLine(prod7.Equals(prod8))
        '</Snippet7>

        '<Snippet8>
        ' The following statement will not compile, because Name is a key
        ' property and its value cannot be changed.
        ' prod8.Name = "clamps"

        ' OnHand is not a Key property. Its value can be changed.
        prod8.OnHand = 22

        '</Snippet8>

        '<Snippet9>
        ' Declaring instances of a named type.
        Dim firstProd1 As New Product("paperclips", 1.29)
        Dim secondProd1 As New Product("desklamp", 28.99)
        Dim thirdProd1 As New Product("stapler", 5.09)

        ' Declaring instances of an anonymous type.
        Dim firstProd2 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim secondProd2 = New With {Key .Name = "desklamp", Key .Price = 28.99}
        Dim thirdProd2 = New With {Key .Name = "stapler", Key .Price = 5.09}
        '</Snippet9>

        '<Snippet10>
        ' Dim thirdProd2 = New With {Key .Nmae = "stapler", Key .Price = 5.09}
        ' Dim thirdProd2 = New With {Key .Name = "stapler", Key .Price = "5.09"}
        ' Dim thirdProd2 = New With {Key .Name = "stapler", .Price = 5.09}
        '</Snippet10>

        '<Snippet11>
        Dim productName As String = "paperclips"
        Dim productPrice As Double = 1.29
        Dim anonProduct = New With {Key productName, Key productPrice}

        ' To create uppercase variable names for the new properties,
        ' assign variables productName and productPrice to uppercase identifiers.
        Dim anonProduct1 = New With {Key .Name = productName, Key .Price = productPrice}
        '</Snippet11>

        '<Snippet12>
        Dim books = <Books>
                        <Book Author="Jesper Aaberg">
                            Advanced Programming Methods
                        </Book>
                    </Books>
        Dim anon = New With {books...<Book>}
        '</Snippet12>
        Console.WriteLine(anon.Book)

        '<Snippet13>
        Dim aString As String = "Example String"
        Dim anon2 = New With {Key aString.First()}
        ' The variable anon2 has one property, First.
        Console.WriteLine(anon2.First)
        '</Snippet13>

        aString = "Act "
        '<Snippet14>
        ' Valid.
        Dim label1 = New With {Key .someLabel = aString & "IV"}
        '</Snippet14>


        '<Snippet15>
        ' Valid.
        Dim anon9 = New With {Key .LastName = "Jones", Key .IDName = .LastName}
        '</Snippet15>


        '<Snippet16>
        ' Valid 
        Dim relationsLabels2 = New With {Key .EqualString = "equals",
                                         Key .GreaterString = "greater than",
                                         Key .LessString = "less than"}
        '</Snippet16>

        '<Snippet17>
        Dim instanceName = New With {Key .Rank = 8,
                                     Key .Title = "Comptroller",
                                     .Location = "headquarters"}
        '</Snippet17>

        '<Snippet18>
        instanceName.Location = "conference"
        Console.WriteLine(instanceName.Title)
        ' The following statement does not compile, because Rank is
        ' a key property and cannot be changed.
        ' instanceName.Rank = 9
        '</Snippet18>

        Dim car As New CarClass With {.Name = "Ford", .ID = 1122445}
        '<Snippet34>
        Dim car1 = New With {Key car.Name, Key car.ID}
        '</Snippet34>

        '<Snippet35>
        Dim car2 = New With {Key .Name = car.Name, Key .ID = car.ID}
        '</Snippet35>

        ' Not valid.
        ' Dim anon5 = New With {Key product.Name, Key car1.Name}

        '<Snippet36>
        ' Valid.
        Dim anon6 = New With {Key .ProductName = product.Name, Key .CarName = car1.Name}
        '</Snippet36>

        ' Dim price = 0
        ' Not valid, because Price and price are the same name.
        ' Dim anon7 = New With {Key product.Price, Key price}


    End Sub

    Function listProducts() As IEnumerable(Of Product)
        Dim productList As New System.Collections.Generic.List(Of Product)
        Dim product0 As New Product With {.Name = "Michael",
                                          .Price = 1.23,
                                          .OnHand = 123}
        Dim product1 As New Product With {.Name = "Svetlana",
                                          .Price = 6.99,
                                          .OnHand = 456}
        Dim product2 As New Product With {.Name = "Michiko",
                                          .Price = 4.59,
                                          .OnHand = 34}
        Dim product3 As New Product With {.Name = "Sven",
                                          .Price = 14.99,
                                          .OnHand = 70}
        Dim product4 As New Product With {.Name = "Hugo",
                                          .Price = 399.98,
                                          .OnHand = 789}
        Dim product5 As New Product With {.Name = "Cesar",
                                          .Price = 1.99,
                                          .OnHand = 890}
        Dim product6 As New Product With {.Name = "Fadi",
                                          .Price = 59.99,
                                          .OnHand = 65}
        productList.Add(product0)
        productList.Add(product1)
        productList.Add(product2)
        productList.Add(product3)
        productList.Add(product4)
        productList.Add(product5)
        productList.Add(product6)
        Return productList
    End Function
    Class Product

        Private _name As String
        Private _price As Double
        Private _onHand As Integer
        Sub New()

        End Sub
        Sub New(ByVal newName As String, ByVal newPrice As Double)
            _name = newName
            _price = newPrice
        End Sub
        Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Property Price() As Double
            Get
                Return _price
            End Get
            Set(ByVal value As Double)
                _price = value
            End Set
        End Property
        Property OnHand() As Integer
            Get
                Return _onHand
            End Get
            Set(ByVal value As Integer)
                _onHand = value
            End Set
        End Property
    End Class

    Class CarClass
        Public Name As String
        Public ID As Integer

    End Class
End Module
