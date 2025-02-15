
namespace ChessLogic
{

    public static class ModeFactory
    {
        public static GamemodeSetup GetMode(GameMode mode)
        {
            return mode switch
            {
                GameMode.Chess960 => new Chess960GamemodeSetup(),
                _ => new StandardGamemodeSetup()
            }
            ;
        }
    }

    public abstract class GamemodeSetup
    {
        public abstract void Setup(Board board);
    }

    public class StandardGamemodeSetup : GamemodeSetup
    {
        public override void Setup(Board board)
        {
            
            board[0, 0] = new Rook(Player.Black);
            board[0, 1] = new Knight(Player.Black);
            board[0, 2] = new Bishop(Player.Black);
            board[0, 3] = new Queen(Player.Black);
            board[0, 4] = new King (Player.Black);
            board[0, 5] = new Bishop(Player.Black);
            board[0, 6] = new Knight(Player.Black);
            board[0, 7] = new Rook(Player.Black);

            board[7, 0] = new Rook(Player.White);
            board[7, 1] = new Knight(Player.White);
            board[7, 2] = new Bishop(Player.White);
            board[7, 3] = new Queen(Player.White);
            board[7, 4] = new King(Player.White);
            board[7, 5] = new Bishop(Player.White);
            board[7, 6] = new Knight(Player.White);
            board[7, 7] = new Rook(Player.White);

            for(int c = 0 ; c < 8; c++)
            {
                board[1, c] = new Pawn(Player.Black);
                board[6, c] = new Pawn(Player.White);
            }
        }
    }
    public class Chess960GamemodeSetup : GamemodeSetup
    {
        
        /*
         * The bishops are placed on opposite-colored squares
         * The king is placed between the rooks
         * Black's pieces are placed equal-and-opposite to White's
         */
        public override void Setup(Board board)
        {
            for(int c = 0 ; c < 8; c++)
            {
                board[1, c] = new Pawn(Player.Black);
                board[6, c] = new Pawn(Player.White);
            }
            
            //place bishop
            //place other bishop on opposite color square
            //place knight
            //place knight
            //place queen
            //place rook
            //place king
            //place rook
            
            List<int> allOptions = new List<int>(){0,1,2,3,4,5,6,7};
            int bishop1Index = GetRandomIndex(allOptions);
            allOptions.Remove(bishop1Index);
            List<int> bishop2Options = new();
            for (int i = 0; i < 8; i++)
            {
                if(i % 2 != bishop1Index % 2) bishop2Options.Add(i);
            }
            int bishop2Index = GetRandomIndex(bishop2Options);
            allOptions.Remove(bishop2Index);
            int knight1Index = GetRandomIndex(allOptions);
            allOptions.Remove(knight1Index);
            int knight2Index = GetRandomIndex(allOptions);
            allOptions.Remove(knight2Index);
            int queenIndex = GetRandomIndex(allOptions);
            allOptions.Remove(queenIndex);
            int rook1Index = allOptions[0];
            int kingIndex = allOptions[1];
            int rook2Index = allOptions[2];
            
            board[0, bishop1Index] = new Bishop(Player.Black);
            board[0, bishop2Index] = new Bishop(Player.Black);
            board[0, knight1Index] = new Knight(Player.Black);
            board[0, knight2Index] = new Knight(Player.Black);
            board[0, queenIndex] = new Queen(Player.Black);
            board[0, rook1Index] = new Rook(Player.Black);
            board[0, kingIndex] = new King(Player.Black);
            board[0, rook2Index] = new Rook(Player.Black);
            
            board[7, bishop1Index] = new Bishop(Player.White);
            board[7, bishop2Index] = new Bishop(Player.White);
            board[7, knight1Index] = new Knight(Player.White);
            board[7, knight2Index] = new Knight(Player.White);
            board[7, queenIndex] = new Queen(Player.White);
            board[7, rook1Index] = new Rook(Player.White);
            board[7, kingIndex] = new King(Player.White);
            board[7, rook2Index] = new Rook(Player.White);

        }

        private int GetRandomIndex(List<int> options)
        {
            return options[Random.Shared.Next() % options.Count];
        }
    }
    
}
