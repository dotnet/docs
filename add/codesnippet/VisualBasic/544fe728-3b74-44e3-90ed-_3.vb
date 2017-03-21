        ' Unlike the default Item property on the SortedList class
        ' itself, IDictionary.Item does not throw an exception
        ' if the requested key is not in the sorted list.
        Console.WriteLine("For key = ""tif"", value = {0}.", _
            openWith("tif"))