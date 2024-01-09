module example1

// <Snippet1>
open System
open System.Collections.Generic

[<Struct; CustomEquality; NoComparison>]
type OrderOrderLine(orderId: int, orderLineId: int) =
    member _.OrderId = orderId
    member _.OrderLineId = orderLineId

    override _.GetHashCode() = 
        HashCode.Combine(orderId, orderLineId)

    override this.Equals(obj) =
        match obj with
        | :? OrderOrderLine as o -> (this :> IEquatable<_>).Equals o
        | _ -> false

    interface IEquatable<OrderOrderLine> with
        member _.Equals(other: OrderOrderLine) = 
            orderId = other.OrderId && orderLineId = other.OrderLineId

let set =
    HashSet<OrderOrderLine> [ OrderOrderLine(1, 1); OrderOrderLine(1, 1); OrderOrderLine(1, 2) ]
printfn $"Item count: {set.Count}."

// The example displays the following output:
// Item count: 2.
// </Snippet1>