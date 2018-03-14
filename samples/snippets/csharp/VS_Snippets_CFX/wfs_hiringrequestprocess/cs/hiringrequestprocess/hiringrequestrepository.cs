//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace Microsoft.Samples.HiringRequest
{

    // Repository of hiring request data
    public class HiringRequestRepository
    {
        private string rootRepositoryPath;

        public HiringRequestRepository()
        {
            this.rootRepositoryPath = string.Empty;
        }

        public HiringRequestRepository(string rootPath)
        {
            this.rootRepositoryPath = rootPath;
        }

        public void Save(HiringRequestInfo hiringRequestInfo)
        {
            // get the path of the archive file
            string filePath = GetRequestInfoFolder() + hiringRequestInfo.Id.ToString() + ".data.xml";

            // save the data in the file
            XElement requestInfo =
                new XElement("hiringRequest",
                        new XAttribute("id", hiringRequestInfo.Id.ToString()),
                        new XAttribute("requesterId", hiringRequestInfo.RequesterId),
                        new XAttribute("created", hiringRequestInfo.CreationDate),
                        new XAttribute("positionId", hiringRequestInfo.PositionId),
                        new XAttribute("departmentId", hiringRequestInfo.DepartmentId),
                        new XElement("description", hiringRequestInfo.Description));
            requestInfo.Save(filePath);
        }

        public HiringRequestInfo Load(string hiringRequestId)
        {         
            // get the path of the archive file
            string filePath = GetRequestInfoFolder() + hiringRequestId + ".data.xml";
            XElement elem = XElement.Load(filePath);

            return new HiringRequestInfo
            {
                Id = new Guid(hiringRequestId),
                RequesterId = elem.Attribute("requesterId").Value,
                DepartmentId = elem.Attribute("departmentId").Value,
                PositionId = elem.Attribute("positionId").Value,
                Description = elem.Element("description").Value
            };
        }

        public IList<HiringRequestInfoAction> GetHiringRequestHistory(string requestId)
        {                    
            // filter elements for the requested user            
            XElement elem = XElement.Load(GetHistoryFolder() + requestId + ".xml");

            // create and return the list of inbox items
            IList<HiringRequestInfoAction> ret = new List<HiringRequestInfoAction>();
            foreach (XElement e in elem.Descendants("item"))
            {
                ret.Add(
                    new HiringRequestInfoAction
                    {
                        Date = DateTime.Parse(e.Element("Date").Value, new CultureInfo("EN-us")),
                        Action = GetElemValue("Action", e),
                        SourceState = GetElemValue("State", e),
                        EmployeeId = GetElemValue("EmployeeId", e),
                        EmployeeName = GetElemValue("EmployeeName", e),
                        Comment = GetElemValue("Comment", e)
                    });
            }
            return ret;
        }

        string GetElemValue(string name, XElement e)
        {
            if (e.Element(name) != null)
            {
                return e.Element(name).Value;
            }
            else
            {
                return "";
            }
        }
        
        // Folder with the information of requests
        string GetRequestInfoFolder()
        {
            // get the path where the request info is stored
            string path = ConfigurationManager.AppSettings["requestInfoArchiveFolder"];
            if (!string.IsNullOrEmpty(this.rootRepositoryPath))
            {
                path = Path.GetFullPath(this.rootRepositoryPath + path);
            }

            // create folder if it does not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        // folder with the history information of request (obtained via a custom tracking participant)
        string GetHistoryFolder()
        {
            // create folder if it does not exist
            string path = ConfigurationManager.AppSettings["requestHistoryFolder"];
            if (!string.IsNullOrEmpty(this.rootRepositoryPath))
            {
                path = Path.GetFullPath(this.rootRepositoryPath + path);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }    
}
