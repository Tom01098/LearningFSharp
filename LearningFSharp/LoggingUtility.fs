module LoggingUtility

let logInt = printfn "%i"
let logBool = printfn "%b"
let logFloat = printfn "%f"
let logStr = printfn "%s"
let logObj<'a> = printfn "%A"
