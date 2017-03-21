' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web", _
    512, Int32.MaxValue))