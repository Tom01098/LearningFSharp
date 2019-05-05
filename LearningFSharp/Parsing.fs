module Parsing

open System

/// The result of a parser function.
type ParseResult<'a> =
    | Success of 'a
    | Failure of string

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
        | Failure message -> Failure message
        | Success fRemaining ->
            let sResult = parse second fRemaining

            match sResult with
            | Failure message -> Failure message
            | Success sRemaining -> Success sRemaining

    Parser inner

/// 'or else' combinator.
let ( <|> ) first second =
    let inner input =
        let fResult = parse first input

        match fResult with
        | Success fRemaining -> Success fRemaining
        | Failure _ ->
            let sResult = parse second input

            match sResult with
            | Success sRemaining -> Success sRemaining
            | Failure message -> Failure message

    Parser inner

/// 'optional' combinator.
let ( !? ) parser = 
    let inner input = 
        let result = parse parser input

        match result with
        | Success remaining -> Success remaining
        | Failure _ -> Success input

    Parser inner

/// Parse a string.
let pString string =
    let inner input =
        let strLen = String.length string

        if String.IsNullOrEmpty(input) then
            Failure "Empty input"
        elif input.Length < strLen then
            Failure "Input was shorter than the string to match against"
        else
            let str = input.[0..strLen-1]

            if str = string then
                Success input.[strLen..]
            else
                Failure "Input did not match string"
            

    Parser inner

/// Parse a single character.
let pChar char =
    let inner input =
        if String.IsNullOrEmpty(input) then
            Failure "Empty input"
        else
            let inputChar = input.[0]

            if inputChar = char then
                Success input.[1..]
            else
                Failure "Characters do not match"

    Parser inner

/// Parse an empty string.
let pEmpty =
    let inner input =
        if String.IsNullOrEmpty(input) then
            Success ""
        else
            Failure "Expected an empty input"

    Parser inner
