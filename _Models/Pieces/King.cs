using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess
{
    public class King : Piece, IDraggable
    {
        public King(Texture2D tex, Vector2 position) : base(tex, position)
        {
            (this as IDraggable).RegisterDraggable();
        }
    }
}