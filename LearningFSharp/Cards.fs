module Cards

type CardValue =
    private
    | Number of int
    | Ace
    | Jack
    | Queen
    | King

let create num = 
    match num with
    | 1 -> Ok Ace
    | 11 -> Ok Jack
    | 12 -> Ok Queen
    | 13 -> Ok King
    | _ when num > 1 && num < 11 -> Ok <| Number num
    | _ -> Error <| sprintf "Number %i is not a valid card number." num
