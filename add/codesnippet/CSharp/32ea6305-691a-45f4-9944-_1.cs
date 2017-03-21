                ArrayList itemsList = (ArrayList)dictionary["List"];
                for (int i=0; i<itemsList.Count; i++)
                    list.Add(serializer.ConvertToType<ListItem>(itemsList[i]));