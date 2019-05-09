open BinarySearchTree
open LoggingUtility
open System
open Parsing
open FizzBuzz
open Cards

[<EntryPoint>]
let main argv =
    logObj <| create 0 Hearts
    logObj <| create 1 Clubs
    logObj <| create 2 Spades
    logObj <| create 3 Diamonds
    logObj <| create 4 Hearts
    logObj <| create 5 Clubs
    logObj <| create 6 Spades
    logObj <| create 7 Diamonds
    logObj <| create 8 Hearts
    logObj <| create 9 Clubs
    logObj <| create 10 Spades
    logObj <| create 11 Diamonds
    logObj <| create 12 Hearts
    logObj <| create 13 Clubs
    logObj <| create 14 Spades

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
