        ' Create an ArrayList to contain
        ' the property items of the configuration
        ' section.
        Dim configPropertyAL As ArrayList = _
         New ArrayList(lockedAttribList.Count)
        For Each propertyItem As _
         PropertyInformation In _
         configSection.ElementInformation.Properties
          configPropertyAL.Add(propertyItem.Name.ToString())
        Next
        ' Copy the elements of the ArrayList to a string array.
        Dim myArr As [String]() = _
        CType(configPropertyAL.ToArray(GetType(String)), [String]())
        ' Create as a comma delimited list.
        Dim propList As String = String.Join(",", myArr)
        ' Lock the items in the list.
        lockedAttribList.SetFromList(propList)