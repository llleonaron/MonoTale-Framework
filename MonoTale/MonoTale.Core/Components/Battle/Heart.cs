using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTale.Core.Common.ObjectManagement;    

namespace MonoTale.Core.Components.Battle;

internal class Heart: IObject
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    private Vector2 Position { get; set; }
    
    private float MoveSpeedNormal { get; set; }
    private float MoveSpeedHalved => Convert.ToByte(Math.Floor(MoveSpeedNormal / 2f));
    private float MoveSpeed { get; set; }
    
    public Texture2D Sprite { get; set; }
    public Color SpriteColor { get; set; }

    internal Heart(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    private void MoveSpeedAssign()
    {
        MoveSpeedNormal = 2f;
        if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
        {
            MoveSpeed = MoveSpeedHalved;
        }
        else
        {
            MoveSpeed = MoveSpeedNormal;
        }
    }

    private void Move()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            X -= MoveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            X += MoveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Y -= MoveSpeed;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            Y += MoveSpeed;
        }
    }

    public void Initialize()
    {
        SpriteColor = Color.Red;
    }

    public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager)
    {
        Sprite = contentManager.Load<Texture2D>("MGSPR_BattleHeartDownOutlined_00");
    }

    public void UnloadContent()
    {

    }

    public void Update(GameTime gameTime)
    {
        MoveSpeedAssign();
        Move();

        Position = new Vector2(X, Y);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw
        (
            Sprite,
            Position, 
            null, 
            SpriteColor,
            0f,
            new Vector2((int)(Sprite.Width / 2), (int)(Sprite.Height / 2)),
            new Vector2(1f, 1f),
            SpriteEffects.None,
            0f
        );
    }
}