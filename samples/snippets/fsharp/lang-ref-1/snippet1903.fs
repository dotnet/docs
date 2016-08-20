type Point = { x : float; y: float; z: float; }
type Point3D = { x: float; y: float; z: float }
// Ambiguity: Point or Point3D?
let mypoint3D = { x = 1.0; y = 1.0; z = 0.0; }