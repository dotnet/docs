module Tracking

// <Include>
/// <summary>Find the latest status of a shipment.</summary>
/// <include file="shared.xml" path="/docs/tracking/*"/>
let status trackingId =
    if trackingId = "SHP-1042" then "Dispatched" else "Unknown"

/// <summary>Find the latest statuses of several shipments.</summary>
/// <include file="shared.xml" path="/docs/tracking/*"/>
let statuses trackingIds =
    trackingIds |> List.map (fun id -> id, status id)
// </Include>

// <Inherit>
[<AbstractClass>]
type TrackingBase() =
    /// <summary>Find the latest status of a shipment.</summary>
    abstract Status: trackingId: string -> string

type TrackingService() =
    inherit TrackingBase()
    /// <inheritdoc/>
    override _.Status trackingId = status trackingId
// </Inherit>
