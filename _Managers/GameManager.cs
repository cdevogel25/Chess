using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess
{
    public class GameManager
    {
        private readonly Pawn _pawn;
        public GameManager()
        {
            var pawnTexture = Globals.Content.Load<Texture2D>("pawn");
            _pawn = new(pawnTexture, new(100, 100));
        }

        public void Update()
        {
            InputManager.Update();
            DragDropManager.Update();
        }

        public void Draw()
        {
            _pawn.Draw();
        }
    }
}
