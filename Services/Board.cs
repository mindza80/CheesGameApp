using ChessGameApp.Components;

using Microsoft.AspNetCore.Components;

namespace ChessGameApp.Services
{
    public class Board
    {
        public static bool WhitePawnLastCell = false;

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
                    y = 0;
                    break;
                case 'b':
                    y = 1;
                    break;
                case 'c':
                    y = 2;
                    break;
                case 'd':
                    y = 3;
                    break;
                case 'e':
                    y = 4;
                    break;
                case 'f':
                    y = 5;
                    break;
                case 'g':
                    y = 6;
                    break;
                case 'h':
                    y = 7;
                    break;
                default:
                    y = -1;
                    break;
            }
            x = int.Parse(location[1].ToString());

            return (BoardLocation)((x * 10) - 10 + (y + 1));
        }

        private static BoardLocation[] GetRookMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;


            for (var tx = x + 1; tx <= 7; tx++)
            {
                if (board.Pieces[tx, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, y));
                }
                else
                {
                    if (board.Pieces[tx, y].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, y));
                    }
                    break;
                }
            }
            for (var tx = x - 1; tx >= 0; tx--)
            {
                if (board.Pieces[tx, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, y));
                }
                else
                {
                    if (board.Pieces[tx, y].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, y));
                    }
                    break;
                }
            }
            for (var ty = y + 1; ty <= 7; ty++)
            {
                if (board.Pieces[x, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x, ty));
                }
                else
                {
                    if (board.Pieces[x, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(x, ty));
                    }
                    break;
                }
            }
            for (var ty = y - 1; ty >= 0; ty--)
            {
                if (board.Pieces[x, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x, ty));
                }
                else
                {
                    if (board.Pieces[x, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(x, ty));
                    }
                    break;
                }
            }
            return legalMoves.ToArray();
        }

        private static BoardLocation[] GetBishopMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            var tx = x;
            var ty = y;
            while (tx < 7 && ty < 7)
            {
                tx++;
                ty++;
                if (board.Pieces[tx, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, ty));
                }
                else
                {
                    if (board.Pieces[tx, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, ty));
                    }
                    break;
                }
            }
            tx = x;
            ty = y;
            while (tx < 7 && ty > 0)
            {
                tx++;
                ty--;
                if (board.Pieces[tx, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, ty));
                }
                else
                {
                    if (board.Pieces[tx, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, ty));
                    }
                    break;
                }
            }
            tx = x;
            ty = y;
            while (tx > 0 && ty < 7)
            {
                tx--;
                ty++;
                if (board.Pieces[tx, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, ty));
                }
                else
                {
                    if (board.Pieces[tx, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, ty));
                    }
                    break;
                }
            }
            tx = x;
            ty = y;
            while (tx > 0 && ty > 0)
            {
                tx--;
                ty--;
                if (board.Pieces[tx, ty] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(tx, ty));
                }
                else
                {
                    if (board.Pieces[tx, ty].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite())
                    {
                        legalMoves.Add(BoardChess.GetLocation(tx, ty));
                    }
                    break;
                }
            }
            return legalMoves.ToArray();
        }

        private static BoardLocation[] GetQueenMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            legalMoves.AddRange(GetBishopMoves(board));
            legalMoves.AddRange(GetRookMoves(board));
            return legalMoves.ToArray();
        }
        
        private static BoardLocation[] GetKnightMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (x < 6 && y < 7 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x + 2, y + 1].PieceIsWhite())
                || board.Pieces[x + 2, y + 1] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 2, y + 1));
            }
            if (x < 6 && y > 0 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x + 2, y - 1].PieceIsWhite())
                || board.Pieces[x + 2, y - 1] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 2, y - 1));
            }
            if (x > 1 && y < 7 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x - 2, y + 1].PieceIsWhite())
                || board.Pieces[x - 2, y + 1] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 2, y + 1));
            }
            if (x > 1 && y > 0 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x - 2, y - 1].PieceIsWhite())
                || board.Pieces[x - 2, y - 1] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 2, y - 1));
            }
            if (x < 7 && y < 6 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x + 1, y + 2].PieceIsWhite())
                || board.Pieces[x + 1, y + 2] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 1, y + 2));
            }
            if (x < 7 && y > 1 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x + 1, y - 2].PieceIsWhite())
                || board.Pieces[x + 1, y - 2] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 1, y - 2));
            }
            if (x > 0 && y < 6 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x - 1, y + 2].PieceIsWhite())
                || board.Pieces[x - 1, y + 2] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 1, y + 2));
            }
            if (x > 0 && y > 1 &&
                ((board.SelectedPiece.Piece.PieceIsWhite() != board.Pieces[x - 1, y - 2].PieceIsWhite())
                || board.Pieces[x - 1, y - 2] == PieceWithColor.EmptySquare))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 1, y - 2));
            }
            return legalMoves.ToArray();
        }

        private static BoardLocation[] GetKingMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (x < 7 && y < 7 && (board.Pieces[x + 1, y + 1] == PieceWithColor.EmptySquare
                || board.Pieces[x + 1, y + 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 1, y + 1));
            }
            if (x < 7 && (board.Pieces[x + 1, y] == PieceWithColor.EmptySquare
                || board.Pieces[x + 1, y].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 1, y));
            }
            if (x < 7 && y > 0 && (board.Pieces[x + 1, y - 1] == PieceWithColor.EmptySquare
                || board.Pieces[x + 1, y - 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x + 1, y - 1));
            }
            if (y < 7 && (board.Pieces[x, y + 1] == PieceWithColor.EmptySquare
                || board.Pieces[x, y + 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x, y + 1));
            }
            if (y > 0 && (board.Pieces[x, y - 1] == PieceWithColor.EmptySquare
                || board.Pieces[x, y - 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x, y - 1));
            }
            if (x > 0 && y < 7 && (board.Pieces[x - 1, y + 1] == PieceWithColor.EmptySquare
                || board.Pieces[x - 1, y + 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 1, y + 1));
            }
            if (x > 0 && (board.Pieces[x - 1, y] == PieceWithColor.EmptySquare
                || board.Pieces[x - 1, y].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 1, y));
            }
            if (x > 0 && y > 0 && (board.Pieces[x - 1, y - 1] == PieceWithColor.EmptySquare
                || board.Pieces[x - 1, y - 1].PieceIsWhite() != board.SelectedPiece.Piece.PieceIsWhite()))
            {
                legalMoves.Add(BoardChess.GetLocation(x - 1, y - 1));
            }
            //Castling
            return legalMoves.ToArray();
        }

        private static BoardLocation[] GetPawnMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                //one move foward
                if (x < 7 && board.Pieces[x + 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x + 1, y));
                }
                //two moves foward
                if (x == 1 && board.Pieces[x + 1, y] == PieceWithColor.EmptySquare && board.Pieces[x + 2, y] == PieceWithColor.EmptySquare)

                {
                    legalMoves.Add(BoardChess.GetLocation(x + 2, y));
                }
                //take right
                if (x < 7 && y < 7 && board.Pieces[x + 1, y + 1] != PieceWithColor.EmptySquare && board.WhitesTurn != board.Pieces[x + 1, y + 1].PieceIsWhite())
                {
                    legalMoves.Add(BoardChess.GetLocation(x + 1, y + 1));
                }
                //take left
                if (x < 7 && y > 0 && board.Pieces[x + 1, y - 1] != PieceWithColor.EmptySquare && board.WhitesTurn != board.Pieces[x + 1, y - 1].PieceIsWhite())
                {
                    legalMoves.Add(BoardChess.GetLocation(x + 1, y - 1));
                }
                if(x == 7)
                {
                    WhitePawnLastCell = true;
                }
            }
            else
            {
                //one move foward
                if (x > 0 && board.Pieces[x - 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 1, y));
                }
                //two moves foward
                if (x == 6 && board.Pieces[x - 1, y] == PieceWithColor.EmptySquare && board.Pieces[x - 2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 2, y));
                }
                //take right
                if (x > 0 && y < 7 && board.Pieces[x - 1, y + 1] != PieceWithColor.EmptySquare && board.WhitesTurn != board.Pieces[x - 1, y + 1].PieceIsWhite())
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 1, y + 1));
                }
                //take left
                if (x > 0 && y > 0 && board.Pieces[x - 1, y - 1] != PieceWithColor.EmptySquare && board.WhitesTurn != board.Pieces[x - 1, y - 1].PieceIsWhite())
                {
                    legalMoves.Add(BoardChess.GetLocation(x - 1, y - 1));
                }
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
            else if (board.SelectedPiece.Piece == PieceWithColor.BlackRook
                    || board.SelectedPiece.Piece == PieceWithColor.WhiteRook)
            {
                return GetRookMoves(board);
            }
            else if (board.SelectedPiece.Piece == PieceWithColor.BlackBishop
                    || board.SelectedPiece.Piece == PieceWithColor.WhiteBishop)
            {
                return GetBishopMoves(board);
            }
            else if (board.SelectedPiece.Piece == PieceWithColor.BlackQueen
                    || board.SelectedPiece.Piece == PieceWithColor.WhiteQueen)
            {
                return GetQueenMoves(board);
            }
            else if (board.SelectedPiece.Piece == PieceWithColor.BlackKing
                    || board.SelectedPiece.Piece == PieceWithColor.WhiteKing)
            {
                return GetKingMoves(board);
            }
            else if (board.SelectedPiece.Piece == PieceWithColor.BlackKnight
                    || board.SelectedPiece.Piece == PieceWithColor.WhiteKnight)
            {
                return GetKnightMoves(board);
            }
            return null;
        }

        public async Task<bool> ContainsPlayerPiece(string location, string figure, bool playerIsWhite)
        {
            var cell = location;

            if (cell == string.Empty) return false;

            return playerIsWhite && PieceIsWhite(figure)
                   || !playerIsWhite && !PieceIsWhite(figure);
        }

        public bool PieceIsWhite(string figure)
        {
            return figure == "♙" || figure == "♖" || figure == "♘" || figure == "♗" || figure == "♕" || figure == "♔";
        }
    }
}

