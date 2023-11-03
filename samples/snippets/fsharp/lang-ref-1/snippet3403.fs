type Ellipse(a0: float, b0: float, theta0: float) =
    let mutable axis1 = a0
    let mutable axis2 = b0
    let mutable rotAngle = theta0
    abstract member Rotate: float -> unit
    default this.Rotate(delta: float) = rotAngle <- rotAngle + delta
