using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess
{
    public class Piece : Sprite, IDraggable
    {
        public Vector2 StartPos;
        public Piece(Texture2D tex, Vector2 position) : base(tex, position)
        {
            this.StartPos = position;
            (this as IDraggable).RegisterDraggable();
        }

        public void SetPos(Vector2 position)
        {
            this.StartPos = position;
        }
    }
}