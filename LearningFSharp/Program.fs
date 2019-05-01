open BinarySearchTree
open LoggingUtility
open System

[<EntryPoint>]
let main argv =
    let mutable tree = createEmptyTree
    tree <- insert tree 6
    tree <- append tree [1..5]
    logObj tree

    logObj (toList tree)
    logObj (toBST [5; 6; 3; 9])

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
