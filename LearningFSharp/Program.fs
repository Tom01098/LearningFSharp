open BinarySearchTree
open LoggingUtility
open System
open Parsing

[<EntryPoint>]
let main argv =
    let parser = (pChar 'A' <|> pChar 'B') .>>. (pChar 'C' <|> pChar 'D') .>>. pEmpty
    logObj <| parse parser "AD"

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
