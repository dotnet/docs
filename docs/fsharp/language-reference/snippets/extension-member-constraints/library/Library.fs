namespace Structural

module Adapters =
    // <Coordinates>
    type System.Numerics.Complex with
        member point.Coordinates = point.Real, point.Imaginary

    type System.Numerics.Vector2 with
        member point.Coordinates = float point.X, float point.Y
    // </Coordinates>

    // <MapAdapters>
    type List<'T> with
        static member Map(source: 'T list, mapping: 'T -> 'U) : 'U list =
            List.map mapping source

    type Option<'T> with
        static member Map(source: 'T option, mapping: 'T -> 'U) : 'U option =
            Option.map mapping source
    // </MapAdapters>

module Algorithms =
    open Adapters

    // <PathLength>
    let inline coordinates (point: ^Point) : float * float =
        (^Point : (member Coordinates: float * float) point)

    let inline pathLength (points: ^Point list) =
        points
        |> List.pairwise
        |> List.sumBy (fun (a, b) ->
            let ax, ay = coordinates a
            let bx, by = coordinates b
            let dx, dy = bx - ax, by - ay
            sqrt (dx * dx + dy * dy))
    // </PathLength>

    // <Map>
    let inline map (mapping: 'T -> 'U) (source: ^Input) : ^Output =
        (^Input :
            (static member Map: ^Input * ('T -> 'U) -> ^Output)
            (source, mapping))
    // </Map>
