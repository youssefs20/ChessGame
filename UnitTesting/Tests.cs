using ChessLogic;

namespace UnitTesting
{

    public class Tests
    {

        [Test]
        public void FactoryGameModeConversionStandardTest_HappyPath()
        {
            //Arrange
            GameMode mode = GameMode.Standard;
            GamemodeSetup setupStrategy;
            //Act
            setupStrategy = ModeFactory.GetMode(mode);
            //Assert
            Assert.That(setupStrategy, Is.TypeOf<StandardGamemodeSetup>());
        }
        [Test]
        public void FactoryGameModeConversionChess960Test_HappyPath()
        {
            //Arrange
            GameMode mode = GameMode.Chess960;
            GamemodeSetup setupStrategy;
            //Act
            setupStrategy = ModeFactory.GetMode(mode);
            //Assert
            Assert.That(setupStrategy, Is.TypeOf<Chess960GamemodeSetup>());
        }
        
        [Test]
        public void StandardSetupTest_HappyPath()
        {
            //Arrange
            Board board = new Board();
            new StandardGamemodeSetup().Setup(board);
            //Act
            //Assert
            Assert.That(board[0, 0], Is.TypeOf<Rook>());
            Assert.That(board[0, 1], Is.TypeOf<Knight>());
            Assert.That(board[0, 2], Is.TypeOf<Bishop>());
            Assert.That(board[0, 3], Is.TypeOf<Queen>());
            Assert.That(board[0, 4], Is.TypeOf<King>());
            Assert.That(board[0, 5], Is.TypeOf<Bishop>());
            Assert.That(board[0, 6], Is.TypeOf<Knight>());
            Assert.That(board[0, 7], Is.TypeOf<Rook>());
        }
        
        
        [Test]
        public void Chess960Setup_BishopsOnOppositeSquares()
        {
            //Arrange
            Board board = new Board();
            new Chess960GamemodeSetup().Setup(board);
            //Act
            int indexOfBishop1 = board.PiecePositionFor(Player.Black).Where(pos => board[pos].GetType() == typeof(Bishop)).First().Column;
            int indexOfBishop2 = board.PiecePositionFor(Player.Black).Where(pos => board[pos].GetType() == typeof(Bishop)).Last().Column;
            //Assert
            Assert.AreEqual(indexOfBishop1 % 2 == 0, indexOfBishop2 % 2 != 0);
        }
        [Test]
        public void Chess960Setup_AllPieces()
        {
            //Arrange
            Board board = new Board();
            new Chess960GamemodeSetup().Setup(board);
            //Act
            int rookCount = board.PiecePositionFor(Player.White).Where(pos => board[pos].GetType() == typeof(Rook))
                .Count();
            int knightCount = board.PiecePositionFor(Player.White).Where(pos => board[pos].GetType() == typeof(Knight))
                .Count();
            int bishopCount = board.PiecePositionFor(Player.White).Where(pos => board[pos].GetType() == typeof(Bishop))
                .Count();
            int queenCount = board.PiecePositionFor(Player.White).Where(pos => board[pos].GetType() == typeof(Queen))
                .Count();
            int kingCount = board.PiecePositionFor(Player.White).Where(pos => board[pos].GetType() == typeof(King))
                .Count();
            //Assert
            Assert.That(rookCount == 2 && knightCount == 2 && bishopCount == 2 && queenCount == 1 && kingCount == 1);
        }
        [Test]
        public void Chess960Setup_MirrorOpponent()
        {
            //Arrange
            Board board = new Board();
            new Chess960GamemodeSetup().Setup(board);
            //Act
            
            //Assert
            Assert.AreEqual(board[0,0].Type, board[7,0].Type);
            Assert.AreEqual(board[0,1].Type, board[7,1].Type);
            Assert.AreEqual(board[0,2].Type, board[7,2].Type);
            Assert.AreEqual(board[0,3].Type, board[7,3].Type);
            Assert.AreEqual(board[0,4].Type, board[7,4].Type);
            Assert.AreEqual(board[0,5].Type, board[7,5].Type);
            Assert.AreEqual(board[0,6].Type, board[7,6].Type);
            Assert.AreEqual(board[0,7].Type, board[7,7].Type);
        }
        [Test]
        public void Chess960Setup_KingCenterRooks()
        {
            //Arrange
            Board board = new Board();
            new Chess960GamemodeSetup().Setup(board);
            //Act
            int indexOfKing = board.PiecePositionFor(Player.Black).Where(pos => board[pos].GetType() == typeof(King)).First().Column;
            int indexOfRook1 = board.PiecePositionFor(Player.Black).Where(pos => board[pos].GetType() == typeof(Rook)).First().Column;
            int indexOfRook2 = board.PiecePositionFor(Player.Black).Where(pos => board[pos].GetType() == typeof(Rook)).Last().Column;
            //Assert
            Assert.That(indexOfRook1 < indexOfKing && indexOfKing < indexOfRook2);
        }
        
    }
}