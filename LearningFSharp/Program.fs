open BinarySearchTree
open LoggingUtility
open System

[<EntryPoint>]
let main argv =
    let a = toBST [5; 2; 3; 7]
    let b = toBST [4; 6; 9]
    let tree = merge a b
    logObj tree

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
