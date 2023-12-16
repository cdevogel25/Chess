using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Chess
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D boardTexture;
        Texture2D pawnTexture;
        Dictionary<string, Piece> pieces;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 512;
            _graphics.PreferredBackBufferHeight = 512;
            _graphics.ApplyChanges();

            pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < 8; i++)
            {
                pieces.Add($"wp{i}", new Piece($"wp{i}", (i * 64, 64)));

            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            boardTexture = Content.Load<Texture2D>("board");
            pawnTexture = Content.Load<Texture2D>("pawn");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();
            var mousePoint = new Point(mouseState.X, mouseState.Y);
                //if (pieceLoc[$"wp0"].Contains(mousePoint) )
                //{
                //    isClicked = mouseState.LeftButton == ButtonState.Pressed;
                //}
            if (pieces["wp0"].PieceBound.Contains(mousePoint) && mouseState.LeftButton == ButtonState.Pressed)
            {
                pieces["wp0"].Grabbed = true;
                pieces["wp0"].PieceBound.X = mousePoint.X;
                pieces["wp0"].PieceBound.Y = mousePoint.Y;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(boardTexture, new Rectangle(0,0,512,512), Color.White);
            
            for (int i = 0;i < 8;i++)
            {
                _spriteBatch.Draw(pawnTexture, pieces[$"wp{i}"].PieceBound, Color.White);
            }

            if (pieces["wp0"].Grabbed)
            {

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class Piece
    {
        public string PieceName;
        public (int, int) PieceLoc;
        public Rectangle PieceBound;
        public bool Grabbed;

        public Piece(string pieceName, (int, int) pieceLoc)
        {
            PieceName = pieceName;
            PieceLoc = pieceLoc;
            PieceBound = new Rectangle(PieceLoc.Item1, PieceLoc.Item2, 64, 64);
            Grabbed = false;
        }
    }
}