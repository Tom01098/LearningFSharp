open BinarySearchTree
open LoggingUtility
open System
open Parsing
open FizzBuzz

[<EntryPoint>]
let main argv =
    FizzBuzzUpTo 15

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
