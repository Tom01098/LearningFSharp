module Parsing

open System

/// The result of a parser function.
type ParseResult<'a> =
    | Success of 'a * string
    | Failure of string * string

/// A parser function which takes a string input.
type Parser<'a> = Parser of (string -> ParseResult<'a>)

/// Parse an input with a given parser.
let parse parser input =
    let (Parser inner) = parser
    inner input

/// 'and then' combinator.
let ( .>>. ) first second =
    let inner input =
        let fResult = parse first input

        match fResult with
        | Failure (message, input) -> Failure (message, input)
        | Success (fValue, fRemaining) ->
            let sResult = parse second fRemaining

            match sResult with
            | Failure (message, input) -> Failure (message, input)
            | Success (sValue, sRemaining) ->
                let newValue = (fValue, sValue)
                Success (newValue, sRemaining)

    Parser inner

/// 'or else' combinator.
let ( <|> ) first second =
    let inner input =
        let fResult = parse first input

        match fResult with
        | Success (fValue, fRemaining) -> Success (fValue, fRemaining)
        | Failure _ ->
            let sResult = parse second input

            match sResult with
            | Success (sValue, sRemaining) -> Success (sValue, sRemaining)
            | Failure (message, input) -> Failure (message, input)

    Parser inner

/// Parse a single character.
let pChar char =
    let inner input =
        if String.IsNullOrEmpty(input) then
            Failure ("Empty input", input)
        else
            let inputChar = input.[0]

            if inputChar = char then
                Success (inputChar, input.[1..])
            else
                Failure ("Characters do not match", input)

    Parser inner
