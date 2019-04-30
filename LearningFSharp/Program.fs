open BinarySearchTree
open LoggingUtility
open System

[<EntryPoint>]
let main argv =
    let mutable tree = createEmptyTree
    tree <- insert tree 6
    tree <- insert tree 8
    tree <- insert tree 3
    tree <- insert tree 1
    tree <- insert tree 9
    tree <- insert tree 7
    tree <- insert tree 4
    tree <- insert tree 5
    tree <- insert tree 7
    logObj tree

    assert (contains tree 8)
    assert (contains tree 3)
    assert (contains tree 9)
    assert (contains tree 1)
    assert not (contains tree 2)
    assert not (contains tree 10)

    logObj (toList tree)

    // Waiting for a key press before closing the console.
    Console.ReadKey() |> ignore
    0
