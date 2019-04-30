module BinarySearchTree

/// A recursively-defined Binary Search Tree (BST).
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

/// Create an empty BST.
let createEmptyTree = Empty

/// Create a BST with the given value as the root.
let createTree value = Node (value, Empty, Empty)
