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
            ((int)location / 10, ((int)location % 10) - 1);
    }
    public class SelectedPiece
    {
        public PieceWithColor Piece { get; init; }
        public BoardLocation Location { get; init; }
    }
    public enum BoardLocation
    {
        A1 = 01, A2 = 02, A3 = 03, A4 = 04, A5 = 05, A6 = 06, A7 = 07, A8 = 08,
        B1 = 11, B2 = 12, B3 = 13, B4 = 14, B5 = 15, B6 = 16, B7 = 17, B8 = 18,
        C1 = 21, C2 = 22, C3 = 23, C4 = 24, C5 = 25, C6 = 26, C7 = 27, C8 = 28,
        D1 = 31, D2 = 32, D3 = 33, D4 = 34, D5 = 35, D6 = 36, D7 = 37, D8 = 38,
        E1 = 41, E2 = 42, E3 = 43, E4 = 44, E5 = 45, E6 = 46, E7 = 47, E8 = 48,
        F1 = 51, F2 = 52, F3 = 53, F4 = 54, F5 = 55, F6 = 56, F7 = 57, F8 = 58,
        G1 = 61, G2 = 62, G3 = 63, G4 = 64, G5 = 65, G6 = 66, G7 = 67, G8 = 68,
        H1 = 71, H2 = 72, H3 = 73, H4 = 74, H5 = 75, H6 = 76, H7 = 77, H8 = 78
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

