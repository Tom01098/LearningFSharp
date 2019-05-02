module Parsing

open System

/// The result of parsing.
type Result<'a> =
    | Success of 'a
    | Failure of string

/// Wrapper for a parser function which transforms a string input
/// into a result and a string of the remaining input.
type Parser<'a> = Parser of (string -> Result<'a> * string)

/// Execute a parser function with input.
let parse parser input =
    let (Parser inner) = parser
    inner input

/// Successful if the current character is the same as the given one.
let pchar char =
    let inner str =
        if String.IsNullOrEmpty(str) then
            (Failure "Empty string", str)
        else
            let first = str.[0]

            if first = char then
                (Success str, str.[1..])
            else
                (Failure "Unexpected character", str)

    Parser inner
