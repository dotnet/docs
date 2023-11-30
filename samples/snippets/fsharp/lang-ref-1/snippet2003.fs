type Shape =
    // The value here is the radius.
    | Circle of float
    // The value here is the side length.
    | EquilateralTriangle of double
    // The value here is the side length.
    | Square of double
    // The values here are the height and width.
    | Rectangle of double * double
