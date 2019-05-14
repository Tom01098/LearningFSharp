module Railway

type Result<'Success, 'Failure> =
    | Success of 'Success
    | Failure of 'Failure

let succeed x = Success x
let fail x = Failure x

// Call a success or failure function depending on the input.
let either fSuccess fFailure input =
    match input with
    | Success s -> fSuccess s
    | Failure f -> fFailure f

// Convert a function into a function which accepts a Result,
// calling the inner function with the success value.
let convert f = either f fail
let ( >=> ) f g = f >> convert g