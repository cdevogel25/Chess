using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess
{
    public class Square : Sprite, ITargetable
    {
        public Square(Texture2D tex, Vector2 position) : base(tex, position)
        {
            (this as ITargetable).RegisterTargetable();
        }
    }
}