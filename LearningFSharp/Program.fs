﻿open BinarySearchTree
open LoggingUtility
open System
open Parsing

[<EntryPoint>]
let main argv =
    let parser = (pchar 'A' <|> pchar 'B') .>>. pchar 'C'
    logObj (parse parser "ABCDWWD")

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
