using System.Collections.Generic;
using System.Linq;

public class TcgDuel {

    public TcgDuelDeck MyDeck;
    public TcgDuelDeck OppDeck;
}

public class TcgDuelDeck {

    // C27E my deck order
    // C400 my deck indexes

    // C37E opponent deck order
    // C480 opponent deck indexes

    // wDuelInitialPrizes cc08 has number of prizes
    // TcgDuelDeck deck = new TcgDuelDeck();

    public List<TcgCard> Cards;
    public List<TcgCard> Hand;
    public List<TcgCard> Prizes;
    public List<TcgCard> Deck;
    public List<TcgCard> Discard;

    public int BasicsInHand {
        get { return Hand.Where(card => card is TcgPkmnCard && ((((TcgPkmnCard) card)).Stage == TcgStage.Basic)).Count(); }
    }

    public void Draw() {
        if (Deck.Count == 0) return;

        TcgCard card = Deck[0];
        Deck.RemoveAt(0);
        Hand.Add(card);
    }
}