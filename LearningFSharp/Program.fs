open BinarySearchTree
open LoggingUtility
open System

[<EntryPoint>]
let main argv =
    let mutable tree = createTree 5
    tree <- insert tree 6
    tree <- insert tree 8
    tree <- insert tree 3
    tree <- insert tree 1
    tree <- insert tree 9
    tree <- insert tree 7
    logObj tree

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
