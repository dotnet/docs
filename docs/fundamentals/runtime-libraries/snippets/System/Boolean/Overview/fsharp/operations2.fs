module operations2

// <Snippet13>
let hasServiceCharges = [ true; false ]
let subtotal = 120.62M
let shippingCharge = 2.50M
let serviceCharge = 5.00M

for hasServiceCharge in hasServiceCharges do
    let total = 
        subtotal + shippingCharge + if hasServiceCharge then serviceCharge else 0M
    printfn $"hasServiceCharge = {hasServiceCharge}: The total is {total:C2}."

// The example displays output like the following:
//       hasServiceCharge = True: The total is $128.12.
//       hasServiceCharge = False: The total is $123.12.
// </Snippet13>