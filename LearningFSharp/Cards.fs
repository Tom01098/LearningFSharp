module Cards

type Suit =
    | Clubs
    | Hearts
    | Spades
    | Diamonds
    
type Rank =
    | Ace
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    
type Card = { Suit:Suit; Rank:Rank }

type Deck = 
    | Deck of Card array
    | EmptyDeck

type Hand = 
    | Hand of Card array
    | EmptyHand

/// Create an ordered deck of 52 playing cards.
let newDeck =
    let suits = [|Clubs; Hearts; Spades; Diamonds|]
    let ranks = [|Ace; Two; Three; Four; Five; Six; 
                Seven; Eight; Nine; Ten; Jack; Queen; King|]

    let cards = Array.allPairs suits ranks 
                |> Array.map (fun pair -> { Suit = fst pair; Rank = snd pair })

    Deck cards

/// Deal the top card from the deck.
let deal deck =
    match deck with
    | Deck cards ->
        match cards.Length with
        | 1 -> (Some cards.[0], EmptyDeck)
        | _ -> (Some cards.[0], Deck cards.[1..])
    | EmptyDeck -> (None, EmptyDeck)
