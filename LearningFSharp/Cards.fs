module Cards

// The suit of a playing card.
type CardSuit =
    | Clubs
    | Spades
    | Hearts
    | Diamonds

// The value of a playing card.
// This is private so that only valid values
// can be created through the factory.
type CardValue =
    private
    | Number of int
    | Ace
    | Jack
    | Queen
    | King

// A playing card with a value and a suit.
type Card = { Value:CardValue; Suit:CardSuit }

/// Create a card with a given value and suit.
let create value suit = 
    match value with
    | 1 -> Ok { Value = Ace; Suit = suit }
    | 11 -> Ok { Value = Jack; Suit = suit }
    | 12 -> Ok { Value = Queen; Suit = suit }
    | 13 -> Ok { Value = King; Suit = suit }
    | _ when value > 1 && value < 11 -> Ok <| { Value = Number value; Suit = suit }
    | _ -> Error <| sprintf "'%i' is not a valid card value" value

/// Convert a playing card to a string form.
let AsString {Value = value; Suit = suit} =
    sprintf "%s of %s" (value.ToString()) (suit.ToString())
