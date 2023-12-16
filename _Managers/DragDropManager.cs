using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Chess
{
    public static class DragDropManager
    {
        private static readonly List<IDraggable> _draggables = new();
        private static IDraggable _dragItem;

        public static void AddDraggable(IDraggable item)
        {
            _draggables.Add(item);
        }

        private static void CheckDragStart()
        {
            if (InputManager.MouseClicked)
            {
                foreach (var item in _draggables)
                {
                    if (item.Rectangle.Contains(InputManager.MousePosition))
                    {
                        _dragItem = item;
                        break;
                    }
                }
            }
        }

        private static void CheckDragStop()
        {
            if (InputManager.MouseReleased)
            {
                _dragItem = null;
            }
        }

        public static void Update()
        {
            CheckDragStart();
            if (_dragItem is not null)
            {
                _dragItem.Position = InputManager.MousePosition;
                CheckDragStop();
            }
        }
    }
}