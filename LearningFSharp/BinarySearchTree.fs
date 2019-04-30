module BinarySearchTree

/// A recursively-defined Binary Search Tree (BST).
type Tree<'a when 'a : comparison> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

/// Create an empty BST.
let createEmptyTree = Empty

/// Create a BST with the given value as the root.
let createTree value = Node (value, Empty, Empty)

/// Insert a value into the given BST.
let rec insert tree value =
    match tree with
    | Node (nodeValue, lhs, rhs) when value < nodeValue -> 
        Node (nodeValue, insert lhs value, rhs)
    | Node (nodeValue, lhs, rhs) when value > nodeValue -> 
        Node (nodeValue, lhs, insert rhs value)
    | Node (_, lhs, rhs) -> Node (value, lhs, rhs)
    | Empty -> Node (value, Empty, Empty)

/// Does the given BST contain the value?
let rec contains tree value =
    match tree with
    | Node (nodeValue, lhs, _) when value < nodeValue -> contains lhs value
    | Node (nodeValue, _, rhs) when value > nodeValue -> contains rhs value
    | Node (_, _, _) -> true
    | Empty -> false

/// Convert the given BST into a list.
let rec toList tree =
    match tree with
    | Node (value, lhs, rhs) -> (toList lhs) @ [value] @ (toList rhs)
    | Empty -> []

/// Convert the given list into a BST.
let toBST list =
    let mutable tree = createEmptyTree

    let rec toBSTImpl list =
        match list with
        | head :: tail -> 
            tree <- insert tree head
            toBSTImpl tail
        | [] -> tree

    toBSTImpl list
