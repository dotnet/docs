       #Region "Implementation of IListSource"

       ReadOnly Property ContainsListCollection() As Boolean Implements IListSource.ContainsListCollection
          Get
             Return ListSourceHelper.ContainsListCollection(Me)
          End Get
       End Property


       Function GetList() As IList Implements IListSource.GetList
          Return ListSourceHelper.GetList(Me)
       End Function 'IListSource.GetList

       #End Region