// In Point3D, three immutable values are defined.
// x, y, and z will be initialized to 0.0.
type Point3D =
   struct
      val x: float
      val y: float
      val z: float
   end

// In Point2D, two immutable values are defined.
// Point2D has an explicit constructor.
// You can create zero-initialized instances of Point2D, or you can
// pass in arguments to initialize the values.
type Point2D =
   struct
      val X: float
      val Y: float
      new(x: float, y: float) = { X = x; Y = y }
   end