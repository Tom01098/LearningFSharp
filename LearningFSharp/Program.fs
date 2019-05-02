open BinarySearchTree
open LoggingUtility
open System
open Parsing

[<EntryPoint>]
let main argv =
    let pcharA = pchar 'A'
    logObj (parse pcharA "ss")

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
