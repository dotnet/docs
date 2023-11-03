type Circle(radius: float) =
    inherit Ellipse(radius, radius, 0.0)
    // Circles are invariant to rotation, so do nothing.
    override this.Rotate(_) = ()
