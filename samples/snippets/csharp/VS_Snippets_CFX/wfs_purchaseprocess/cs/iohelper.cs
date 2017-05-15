//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace Microsoft.Samples.WF.PurchaseProcess
{

    /// <summary>
    /// This class is helper to deal with all IO related issues (folders, paths, etc.)
    /// </summary>
    public static class IOHelper
    {
        public static readonly string InstanceFormatString = "{0}.xml";
        public static readonly string PersistenceDirectory = Path.Combine(Path.GetTempPath(), "FilePersistenceProvider");

        public static string GetFileName(Guid id)
        {
            EnsurePersistenceFolderExists();
            return Path.Combine(PersistenceDirectory, string.Format(CultureInfo.InvariantCulture, InstanceFormatString, id));
        }

        public static string GetAllRfpsFileName()
        {
            EnsurePersistenceFolderExists();
            return Path.Combine(PersistenceDirectory, "rfps.xml");
        }

        public static string GetTrackingFilePath(Guid instanceId)
        {
            EnsurePersistenceFolderExists();
            return Path.Combine(PersistenceDirectory, instanceId.ToString() + ".tracking");
        }

        public static void EnsurePersistenceFolderExists()
        {
            if (!Directory.Exists(PersistenceDirectory))
            {
                Directory.CreateDirectory(PersistenceDirectory);
            }
        }

        public static void EnsureAllRfpFileExists()
        {
            string fileName = IOHelper.GetAllRfpsFileName();
            if (!File.Exists(fileName))
            {
                XElement root = new XElement("requestForProposals");
                root.Save(fileName);
            }
        }
    }
}
