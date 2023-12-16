using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess
{
    public class Pawn : Sprite, IDraggable
    {
        private bool firstMove;
        public Pawn(Texture2D tex, Vector2 position) : base(tex, position)
        {
            this.firstMove = true;
            (this as IDraggable).RegisterDraggable();
        }
    }
}
