open BinarySearchTree
open LoggingUtility
open System
open Parsing
open FizzBuzz
open Cards

[<EntryPoint>]
let main argv =
    logObj <| create 0
    logObj <| create 1
    logObj <| create 2
    logObj <| create 3
    logObj <| create 4
    logObj <| create 5
    logObj <| create 6
    logObj <| create 7
    logObj <| create 8
    logObj <| create 9
    logObj <| create 10
    logObj <| create 11
    logObj <| create 12
    logObj <| create 13
    logObj <| create 14

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
