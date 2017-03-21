        Console.WriteLine("Using an XML round trip to reset the fourth " + "permission.")
        sp4.FromXml(sp2.ToXml())
        rc = sp4.Equals(sp2)
        Console.WriteLine("Does the XML round trip result equal the " + "original permission? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements

    End Sub 'ShowMembers
