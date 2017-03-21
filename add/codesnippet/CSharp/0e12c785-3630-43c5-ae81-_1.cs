            Object [] hostEvidence = {myGacInstalled};
            Object [] assemblyEvidence = {};
            Evidence myEvidence = new Evidence(hostEvidence,assemblyEvidence);
            GacIdentityPermission myPerm = 
                (GacIdentityPermission)myGacInstalled.CreateIdentityPermission(
                myEvidence);
            Console.WriteLine(myPerm.ToXml().ToString());