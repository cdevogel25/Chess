using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess
{
    public interface IDraggable
    {
        Rectangle Rectangle { get; }
        Vector2 Position { get; set; }

        void RegisterDraggable()
        {
            DragDropManager.AddDraggable(this);
        }
    }
}