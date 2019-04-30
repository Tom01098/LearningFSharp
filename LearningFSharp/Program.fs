open BinarySearchTree
open LoggingUtility
open System

[<EntryPoint>]
let main argv =
    let tree = createEmptyTree
    logObj tree

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
