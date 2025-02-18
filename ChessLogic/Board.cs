using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        private readonly Dictionary<Player, Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            {Player.White, null },
            {Player.Black, null }
        };
        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Position pos] 
        {
            get { return this[pos.Row ,pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }

        public void SetPawnSkipPosition(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }
        public static Board Initial(GamemodeSetup setupStrategy)
        {
            Board board = new Board();
            setupStrategy.Setup(board);
            return board;
        }

        
        public static bool IsInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        } 

        public IEnumerable<Position> PiecePosition()
        {
            for(int r = 0; r < 8; r++)
            {
                for(int c = 0; c < 8; c++)
                {
                    Position pos = new Position(r, c);
                    if (!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }

        public IEnumerable<Position> PiecePositionFor(Player player)
        {
            return PiecePosition().Where(pos => this[pos].Color == player);
        }

        public bool IsInCheck(Player player)
        {
            return PiecePositionFor(player.Opponent()).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.CanCaptureOpponentKing(pos, this);
            });
        }

        public Board Copy()
        {
            Board copy = new Board();

            foreach(Position pos in PiecePosition())
            {
                copy[pos] = this[pos].Copy();
            }
            return copy;
        }
    }
}
