namespace ChessGameApp.Services
{
    public class BoardChess
    {

        public PieceWithColor[,] Pieces { get; set; }
        public bool WhitesTurn { get; set; }
        public SelectedPiece SelectedPiece { get; set; }
        public History History { get; set; }


        public BoardChess()
        {
            History = new History();
            WhitesTurn = true;
            Pieces = new PieceWithColor[8, 8]
            {
            {
            PieceWithColor.WhiteRook,
            PieceWithColor.WhiteKnight,
            PieceWithColor.WhiteBishop,
            PieceWithColor.WhiteQueen,
            PieceWithColor.WhiteKing,
            PieceWithColor.WhiteBishop,
            PieceWithColor.WhiteKnight,
            PieceWithColor.WhiteRook
            },
            {
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn
            },
            {
            PieceWithColor.BlackRook,
            PieceWithColor.BlackKnight,
            PieceWithColor.BlackBishop,
            PieceWithColor.BlackQueen,
            PieceWithColor.BlackKing,
            PieceWithColor.BlackBishop,
            PieceWithColor.BlackKnight,
            PieceWithColor.BlackRook
            }
            };
        }
        public static BoardLocation GetLocation(int row, int cell) =>
            (BoardLocation)((row * 10) + cell + 1);

        public static (int, int) GetXYFromLocation(BoardLocation location) =>
            ((int)location / 10, ((int)location % 10) -1);
    }
    public class SelectedPiece
    {
        public PieceWithColor Piece { get; init; }
        public BoardLocation Location { get; init; }
    }
    public enum BoardLocation
    {
        A8 = 08, B8 = 18, C8 = 28, D8 = 38, E8 = 48, F8 = 58, G8 = 68, H8 = 78,
        A7 = 07, B7 = 17, C7 = 27, D7 = 37, E7 = 47, F7 = 57, G7 = 67, H7 = 77,
        A6 = 06, B6 = 16, C6 = 26, D6 = 36, E6 = 46, F6 = 56, G6 = 66, H6 = 76,
        A5 = 05, B5 = 15, C5 = 25, D5 = 35, E5 = 45, F5 = 55, G5 = 65, H5 = 75,
        A4 = 04, B4 = 14, C4 = 24, D4 = 34, E4 = 44, F4 = 54, G4 = 64, H4 = 74,
        A3 = 03, B3 = 13, C3 = 23, D3 = 33, E3 = 43, F3 = 53, G3 = 63, H3 = 73,
        A2 = 02, B2 = 12, C2 = 22, D2 = 32, E2 = 42, F2 = 52, G2 = 62, H2 = 72,
        A1 = 01, B1 = 11, C1 = 21, D1 = 31, E1 = 41, F1 = 51, G1 = 61, H1 = 71
    }
    public enum PieceWithColor
    {
        EmptySquare = 0,
        WhitePawn = 11,
        BlackPawn = 1,
        WhiteBishop = 12,
        BlackBishop = 2,
        WhiteKnight = 13,
        BlackKnight = 3,
        WhiteRook = 14,
        BlackRook = 4,
        WhiteQueen = 15,
        BlackQueen = 5,
        WhiteKing = 16,
        BlackKing = 6
    }
    public class History
    {
        public List<Move> Moves { get; set; }
        public History()
        {
            Moves = new List<Move>();
        }
        public void MakeMove(BoardLocation from, BoardLocation to, bool whitesTurn) =>
            Moves.Add(new Move { From = from, To = to, WhitesTurn = whitesTurn });
    }
    public struct Move
    {
        public bool WhitesTurn { get; set; }
        public BoardLocation From { get; set; }
        public BoardLocation To { get; set; }
    }
}

