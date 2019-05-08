module FizzBuzz

// Active Patterns for divisibility.
let (|DivBy3|_|) n = if n % 3 = 0 then Some DivBy3 else None
let (|DivBy5|_|) n = if n % 5 = 0 then Some DivBy5 else None

// Match the number with the Active Pattern.
let FizzBuzzNumber n =
    match n with
    | DivBy3 & DivBy5 -> "FizzBuzz"
    | DivBy3 -> "Fizz"
    | DivBy5 -> "Buzz"
    | _ -> n.ToString()

// Log a FizzBuzz number using printfn.
let LogFizzBuzzNumber n = printfn "%s" <| FizzBuzzNumber n

// Log FizzBuzz numbers between 1 and the given number.
let FizzBuzzUpTo n = [1..n] |> List.iter LogFizzBuzzNumber
