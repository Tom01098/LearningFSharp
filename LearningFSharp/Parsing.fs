module Parsing

open System

type ParseResult<'a> =
    | Success of 'a * string
    | Failure of string

type Parser<'a> = Parser of (string -> ParseResult<'a>)

let parse parser input =
    let (Parser inner) = parser
    inner input

let andThen first second = 
    let inner input =
        let fResult = parse first input

        match fResult with
        | Failure message -> Failure message
        | Success (fValue, fRemaining) ->
            let sResult = parse second fRemaining

            match sResult with
            | Failure message -> Failure message
            | Success (sValue, sRemaining) ->
                let newValue = (fValue, sValue)
                Success (newValue, sRemaining)

    Parser inner

let ( .>>. ) = andThen

let pchar char =
    let inner input =
        if String.IsNullOrEmpty(input) then
            Failure "Empty input"
        else
            let inputChar = input.[0]

            if inputChar = char then
                Success (inputChar, input.[1..])
            else
                Failure "Characters do not match"

    Parser inner
