open BinarySearchTree
open LoggingUtility
open System
open Parsing
open FizzBuzz
open Cards

[<EntryPoint>]
let main argv =
    logObj <| shuffle newDeck

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
