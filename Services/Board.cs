using ChessGameApp.Components;

using Microsoft.AspNetCore.Components;

namespace ChessGameApp.Services
{
    public class Board 
    {
       
       
        public static PieceWithColor GetPiece(string piece)
        {
            switch (piece)
            {
                case "♟":
                    return PieceWithColor.BlackPawn;
                case "♜":
                    return PieceWithColor.BlackRook;
                case "♞":
                    return PieceWithColor.BlackKnight;
                case "♝":
                    return PieceWithColor.BlackBishop;
                case "♚":
                    return PieceWithColor.BlackKing;
                case "♛":
                    return PieceWithColor.BlackQueen;
                case "♙":
                    return PieceWithColor.WhitePawn;
                case "♖":
                    return PieceWithColor.WhiteRook;
                case "♘":
                    return PieceWithColor.WhiteKnight;
                case "♗":
                    return PieceWithColor.WhiteBishop;
                case "♕":
                    return PieceWithColor.WhiteQueen;
                case "♔":
                    return PieceWithColor.WhiteKing;

                default: 
                    return PieceWithColor.EmptySquare;
                    
            }
        }



        public static BoardLocation GetLocation(string location)
        {
            int x;
            int y;

            switch (location[0])
            {
                case 'a':
                    x = 0;
                    break;
                case 'b':  
                    x = 10;
                    break;
                case 'c':
                    x = 20;
                    break;
                case 'd':
                    x = 30;
                    break;
                case 'e':
                    x = 40;
                    break;
                case 'f':
                    x = 50;
                    break;
                case 'g':
                    x = 60;
                    break;
                case 'h':
                    x = 70;
                    break;
                default: 
                    x = -1;
                    break;
            }
            y = int.Parse(location[1].ToString());

            return (BoardLocation)(x + y);

        } 



        public static BoardLocation GetLocation(int row, int cell) =>
            (BoardLocation)((row * 10) + cell + 1);

        public static (int, int) GetXYFromLocation(BoardLocation location) =>
            ((int)location / 10, ((int)location % 10) - 1);


        private static BoardLocation[] GetPawnMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x + 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x + 1, y));
                }
                //two moves foward
                if (x == 1 && board.Pieces[x + 1, y] == PieceWithColor.EmptySquare && board.Pieces[x + 2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x + 2, y));
                }
                //take
                //enpasant
            }
            else
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x - 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 1, y));
                }
                //two moves foward
                if (x == 6 && board.Pieces[x - 1, y] == PieceWithColor.EmptySquare && board.Pieces[x - 2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 2, y));
                }
                //take
                //enpasant
            }
            return legalMoves.ToArray();
        }

        public static BoardLocation[] GetLegalMoves(BoardChess board)
        {
            if (board.SelectedPiece.Piece == PieceWithColor.BlackPawn
                || board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                return GetPawnMoves(board);
            }



            return null;
        }
    }
}
