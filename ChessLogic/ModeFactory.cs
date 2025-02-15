
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
        public override void Setup(Board board)
        {
            
        }
    }
    
}
