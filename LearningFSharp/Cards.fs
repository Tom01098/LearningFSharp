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

/// Create an ordered deck of 52 playing cards.
let newDeck =
    let suits = [Clubs; Hearts; Spades; Diamonds]
    let ranks = [Ace; Two; Three; Four; Five; Six; 
                Seven; Eight; Nine; Ten; Jack; Queen; King]

    let cards = List.allPairs suits ranks 
                |> List.map (fun pair -> { Suit = fst pair; Rank = snd pair })

    Deck cards

/// Deal the top card from the deck.
let deal (Deck deck) =
    match deck with
    | head :: tail -> Some (head, Deck tail)
    | [] -> None