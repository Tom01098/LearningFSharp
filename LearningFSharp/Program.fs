open BinarySearchTree
open LoggingUtility
open System
open Parsing
open FizzBuzz
open Cards
open Railway

let startsWithA (input: string) =
    if input.[0] = 'A'
    then Success input
    else Failure "Does not start with 'A'"

let isLessThan5 input =
    if String.length input < 5
    then Success input
    else Failure "Input is 5+ characters"

let endsWithZ input =
    let index = String.length input - 1
    if input.[index] = 'Z'
    then Success input
    else Failure "Does not end with 'Z'"

[<EntryPoint>]
let main argv =
    let validator = startsWithA >=> isLessThan5 >=> endsWithZ

    validator "ASdZ" |> logObj

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
