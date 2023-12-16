using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Chess
{
    public class GameManager
    {
        private readonly List<Pawn> _pawns = new();
        private readonly List<Square> _squares = new();
        private readonly Sprite _board;
        public GameManager()
        {
            var pawnTexture = Globals.Content.Load<Texture2D>("pawn");
            var squareTexture = Globals.Content.Load<Texture2D>("square");
            var boardTexture = Globals.Content.Load<Texture2D>("board");

            _board = new(boardTexture, new(256, 256));

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _squares.Add(new(squareTexture, new(32 + (i * 64), 32 + (j * 64))));
                }
            }
            for (int i = 0;i < 8; i++)
            {
                _pawns.Add(new(pawnTexture, new(32 + (i * 64), 96)));
            }
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
                item.Draw();
            }

            foreach (var item in _pawns)
            {
                item.Draw();
            }
        }
    }
}
