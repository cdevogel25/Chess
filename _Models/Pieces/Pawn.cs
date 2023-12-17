using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece, IDraggable
    {
        public Pawn(Texture2D tex, Vector2 position) : base(tex, position)
        {
            (this as IDraggable).RegisterDraggable();
        }
    }
}
