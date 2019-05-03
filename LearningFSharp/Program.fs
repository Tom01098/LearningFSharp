open BinarySearchTree
open LoggingUtility
open System
open Parsing

[<EntryPoint>]
let main argv =
    let parser = (pchar 'A' <|> pchar 'B') .>>. (pchar 'C' <|> pchar 'D')
    logObj (parse parser "AD")

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
