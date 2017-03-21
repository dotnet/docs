' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"))