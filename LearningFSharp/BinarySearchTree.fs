module BinarySearchTree

/// A recursively-defined Binary Search Tree (BST).
type Tree<'a> =
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
