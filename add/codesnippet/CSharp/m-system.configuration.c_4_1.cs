        // Create an ArrayList to contain
        // the property items of the configuration
        // section.
        ArrayList configPropertyAL = new ArrayList(lockedAttribList.Count);
        foreach (PropertyInformation propertyItem in
          configSection.ElementInformation.Properties)
        {
          configPropertyAL.Add(propertyItem.Name.ToString());
        }
        // Copy the elements of the ArrayList to a string array.
        String[] myArr = (String[])configPropertyAL.ToArray(typeof(string));
        // Create as a comma delimited list.
        string propList = string.Join(",", myArr);
        // Lock the items in the list.
        lockedAttribList.SetFromList(propList);