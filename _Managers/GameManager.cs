using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Chess
{
    public readonly struct Sprites
    {
        public readonly Texture2D pawn_w { get; }
        public readonly Texture2D bishop_w { get; }
        public readonly Texture2D knight_w { get; }
        public readonly Texture2D rook_w { get; }
        public readonly Texture2D king_w { get; }
        public readonly Texture2D queen_w { get; }

        public readonly Texture2D pawn_b { get; }
        public readonly Texture2D bishop_b { get; }
        public readonly Texture2D knight_b { get; }
        public readonly Texture2D rook_b { get; }
        public readonly Texture2D king_b { get; }
        public readonly Texture2D queen_b { get; }
        public Sprites()
        {
            pawn_w = Globals.Content.Load<Texture2D>("Pieces/White/pawn_w");
            bishop_w = Globals.Content.Load<Texture2D>("Pieces/White/bishop_w");
            knight_w = Globals.Content.Load<Texture2D>("Pieces/White/knight_w");
            rook_w = Globals.Content.Load<Texture2D>("Pieces/White/rook_w");
            king_w = Globals.Content.Load<Texture2D>("Pieces/White/king_w");
            queen_w = Globals.Content.Load<Texture2D>("Pieces/White/queen_w");

            pawn_b = Globals.Content.Load<Texture2D>("Pieces/Black/pawn_b");
            bishop_b = Globals.Content.Load<Texture2D>("Pieces/Black/bishop_b");
            knight_b = Globals.Content.Load<Texture2D>("Pieces/Black/knight_b");
            rook_b = Globals.Content.Load<Texture2D>("Pieces/Black/rook_b");
            king_b = Globals.Content.Load<Texture2D>("Pieces/Black/king_b");
            queen_b = Globals.Content.Load<Texture2D>("Pieces/Black/queen_b");
        }
    }
    public class GameManager
    {
        private readonly List<Pawn> _pawns = new();
        private readonly List<List<Square>> _squares = new();
        private readonly List<Bishop> _bishops = new();
        private readonly List<Knight> _knights = new();
        private readonly List<Rook> _rooks = new();
        private readonly List<King> _kings = new();
        private readonly List<Queen> _queens = new();
        private readonly Sprite _board;
        public GameManager()
        {
            var sprites = new Sprites();
            var boardTexture = Globals.Content.Load<Texture2D>("board");
            var squareTexture = Globals.Content.Load<Texture2D>("square");

            _board = new(boardTexture, new(256, 256));

            for (int i = 0; i < 8; i++)
            {
                _squares.Add(new List<Square>());
                for (int j = 0; j < 8; j++)
                {
                    _squares[i].Add(new(squareTexture, new(32 + (i * 64), 32 + (j * 64))));
                }
            }
            for (int i = 0;i < 8; i++)
            {
                _pawns.Add(new(sprites.pawn_w, new(32 + (i * 64), 96)));
                _pawns.Add(new(sprites.pawn_b, new(32 + (i * 64), 32 + (6 * 64))));
            }
            for (int i = 2; i < 6; i = i + 3)
            {
                _bishops.Add(new(sprites.bishop_w, new(32 + (i * 64), 32)));
                _bishops.Add(new(sprites.bishop_b, new(32 + (i * 64), 32 + (7 * 64))));
            }
            for (int i = 1; i < 7; i = i + 5)
            {
                _knights.Add(new(sprites.knight_w, new(32 + (i * 64), 32)));
                _knights.Add(new(sprites.knight_b, new(32 + (i * 64), 32 + (7 * 64))));
            }
            for (int i = 0; i < 8; i = i + 7)
            {
                _rooks.Add(new(sprites.rook_w, new(32 + (i * 64), 32)));
                _rooks.Add(new(sprites.rook_b, new(32 + (i * 64), 32 + (7 * 64))));
            }

            _kings.Add(new(sprites.king_w, new(32 + (4 * 64), 32)));
            _kings.Add(new(sprites.king_b, new(32 + (4 * 64), 32 + (7 * 64))));

            _queens.Add(new(sprites.queen_w, new(32 + (3 * 64), 32)));
            _queens.Add(new(sprites.queen_b, new(32 + (3 * 64), 32 + (7 * 64))));
        }

        public void Update()
        {
            InputManager.Update();
            DragDropManager.Update();
        }

        public void Draw()
        {
            _board.Draw();
            foreach (var item in _squares)
            {
                foreach (var square in item)
                {
                    square.Draw();
                }
            }

            foreach (var item in _pawns)
            {
                item.Draw();
            }

            foreach (var item in _bishops)
            {
                item.Draw();
            }

            foreach (var item in _knights)
            {
                item.Draw();
            }

            foreach (var item in _rooks)
            {
                item.Draw();
            }
            
            foreach (var item in _kings)
            {
                item.Draw();
            }

            foreach (var item in _queens)
            {
                item.Draw();
            }
        }
    }
}
