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

type Deck = Deck of Card list
type Hand = Hand of Card list

let Deal (Deck deck) =
    match deck with
    | head :: tail -> Some (head, Deck tail)
    | [] -> None