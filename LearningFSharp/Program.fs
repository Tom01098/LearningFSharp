open BinarySearchTree
open LoggingUtility
open System
open Parsing

[<EntryPoint>]
let main argv =
    let parser = pString "Hello" 
                 .>>. pChar ' '
                 .>>. pString "World"
                 .>>. !? (pChar '!')
                 .>>. pEmpty
                 

    logObj <| parse parser "Hello World"

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
