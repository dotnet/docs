    ' Declare the Urls collection property using the
    ' ConfigurationCollectionAttribute.
    ' This allows to build a nested section that contains
    ' a collection of elements.
    <ConfigurationProperty("urls", IsDefaultCollection:=False),
        System.Configuration.ConfigurationCollection(GetType(UrlsCollection),
        AddItemName:="add", ClearItemsName:="clear", RemoveItemName:="remove")> _
    Public ReadOnly Property Urls() As UrlsCollection
        Get
            Dim urlsCollection As UrlsCollection = CType(MyBase.Item("urls"), UrlsCollection)
            Return urlsCollection
        End Get
    End Property