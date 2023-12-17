using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess
{
    public class Queen : Piece, IDraggable
    {
        public Queen(Texture2D tex, Vector2 position) : base(tex, position)
        {
            (this as IDraggable).RegisterDraggable();
        }
    }
}