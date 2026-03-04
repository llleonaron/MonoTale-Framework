using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTale.Core.Common.UI;

internal sealed class NineSliceTiledTexture2D
{
    private Texture2D Sprite { get; set; }
    
    private int SpriteWidthOneThird => (Sprite.Width / 3);
    private int SpriteHeightOneThird => (Sprite.Height / 3);
    
    private int TopLeftCornerX { get; set; }
    private int TopLeftCornerY { get; set; }
    private int BottomRightCornerX { get; set; }
    private int BottomRightCornerY { get; set; }

    private int BoxWidth => (BottomRightCornerX - TopLeftCornerX);
    private int BoxHeight => (BottomRightCornerY - TopLeftCornerY);

    private int BoxColumns => (BoxWidth / SpriteWidthOneThird);
    private int BoxRows => (BoxHeight / SpriteHeightOneThird);

    private Vector2[] SpriteSlicePositions { get; set; }

    enum PositionType
    {
        TopLeft,
        TopCenter,
        TopRight,

        MiddleLeft,
        MiddleCenter,
        MiddleRight,

        BottomLeft,
        BottomCenter,
        BottomRight,
    }

    internal NineSliceTiledTexture2D(Texture2D sprite, int topLeftCornerX, int topLeftCornerY, int bottomRightCornerX, int bottomRightCornerY)
    {
        Sprite = sprite;

        TopLeftCornerX = topLeftCornerX;
        TopLeftCornerY = topLeftCornerY;
        BottomRightCornerX = bottomRightCornerX;
        BottomRightCornerY = bottomRightCornerY;
        
        const int sliceCount = 9;

        SpriteSlicePositions = new Vector2[sliceCount];
}
    
    void DrawTopLeftSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        SpriteSlicePositions[(int)PositionType.TopLeft] = new(TopLeftCornerX, TopLeftCornerY);
        spriteBatch.Draw
        (
            sprite, 
            SpriteSlicePositions[(int)PositionType.TopLeft], 
            new Rectangle(0, 0, (Sprite.Width / 3), (Sprite.Height / 3)), 
            Color.White,
            0f,
            Vector2.Zero,
            new Vector2(1f, 1f),
            SpriteEffects.None,
            0f
        );
    }

    void DrawTopCenterSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        for (int i = 1; i < (BoxColumns); i++)
        {
            SpriteSlicePositions[(int)PositionType.TopCenter] = new(TopLeftCornerX + (i * SpriteWidthOneThird), TopLeftCornerY);
            spriteBatch.Draw
            (
                sprite, 
                SpriteSlicePositions[(int)PositionType.TopCenter], 
                new Rectangle(SpriteWidthOneThird, 0, (Sprite.Width / 3), (Sprite.Height / 3)), 
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1f, 1f),
                SpriteEffects.None,
                0f
            );
        }
    }

    void DrawTopRightSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        SpriteSlicePositions[(int)PositionType.TopRight] = new(TopLeftCornerX + (BoxColumns * SpriteWidthOneThird), TopLeftCornerY);
        spriteBatch.Draw
        (
            sprite, 
            SpriteSlicePositions[(int)PositionType.TopRight], 
            new Rectangle((SpriteWidthOneThird * 2), 0, (Sprite.Width / 3), (Sprite.Height / 3)), 
            Color.White,
            0f,
            Vector2.Zero,
            new Vector2(1f, 1f),
            SpriteEffects.None,
            0f
        );
    }

    void DrawMiddleLeftSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        for (int i = 1; i < (BoxRows); i++)
        {
            SpriteSlicePositions[(int)PositionType.MiddleLeft] = new(TopLeftCornerX, TopLeftCornerY + (i * SpriteHeightOneThird));
            spriteBatch.Draw
            (
                sprite, 
                SpriteSlicePositions[(int)PositionType.MiddleLeft], 
                new Rectangle(0, SpriteHeightOneThird, (Sprite.Width / 3), (Sprite.Height / 3)), 
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1f, 1f),
                SpriteEffects.None,
                0f
            );
        }
    }

    void DrawMiddleCenterSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        for (int i = 1; i < (BoxColumns); i++)
        {
            for (int j = 1; j < (BoxRows); j++)
            {
                SpriteSlicePositions[(int)PositionType.TopLeft] = new(TopLeftCornerX + (i * SpriteWidthOneThird), TopLeftCornerY + (j * SpriteHeightOneThird));
                spriteBatch.Draw
                (
                    sprite, 
                    SpriteSlicePositions[(int)PositionType.TopLeft], 
                    new Rectangle(SpriteWidthOneThird, SpriteHeightOneThird, (Sprite.Width / 3), (Sprite.Height / 3)), 
                    Color.White,
                    0f,
                    Vector2.Zero,
                    new Vector2(1f, 1f),
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }

    void DrawMiddleRightSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        for (int i = 1; i < (BoxRows); i++)
        {
            SpriteSlicePositions[(int)PositionType.MiddleRight] = new(TopLeftCornerX + (BoxColumns * SpriteWidthOneThird), TopLeftCornerY + (i * SpriteHeightOneThird));
            spriteBatch.Draw
            (
                sprite, 
                SpriteSlicePositions[(int)PositionType.MiddleRight], 
                new Rectangle(SpriteWidthOneThird * 2, SpriteHeightOneThird, (Sprite.Width / 3), (Sprite.Height / 3)), 
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1f, 1f),
                SpriteEffects.None,
                0f
            );
        }
    }

    void DrawBottomLeftSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        SpriteSlicePositions[(int)PositionType.BottomLeft] = new(TopLeftCornerX, TopLeftCornerY + (BoxRows * SpriteHeightOneThird));
        spriteBatch.Draw
        (
            sprite, 
            SpriteSlicePositions[(int)PositionType.BottomLeft], 
            new Rectangle(0, (SpriteHeightOneThird * 2), Sprite.Width / 3, Sprite.Height / 3), 
            Color.White,
            0f,
            Vector2.Zero,
            new Vector2(1f, 1f),
            SpriteEffects.None,
            0f
        );
    }

    void DrawBottomCenterSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        for (int i = 1; i < (BoxColumns); i++)
        {
            SpriteSlicePositions[(int)PositionType.TopCenter] = new(TopLeftCornerX + (i * SpriteWidthOneThird), TopLeftCornerY + (BoxRows * SpriteHeightOneThird));
            spriteBatch.Draw
            (
                sprite, 
                SpriteSlicePositions[(int)PositionType.TopCenter], 
                new Rectangle(SpriteWidthOneThird, (SpriteHeightOneThird * 2), (Sprite.Width / 3), (Sprite.Height / 3)), 
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1f, 1f),
                SpriteEffects.None,
                0f
            );
        }
    }

    void DrawBottomRightSlice(Texture2D sprite, SpriteBatch spriteBatch)
    {
        SpriteSlicePositions[(int)PositionType.BottomRight] = new(TopLeftCornerX + (BoxColumns * SpriteWidthOneThird), TopLeftCornerY + (BoxRows * SpriteHeightOneThird));
        spriteBatch.Draw
        (
            sprite, 
            SpriteSlicePositions[(int)PositionType.BottomRight], 
            new Rectangle((SpriteHeightOneThird * 2), (SpriteHeightOneThird * 2), Sprite.Width / 3, Sprite.Height / 3), 
            Color.White,
            0f,
            Vector2.Zero,
            new Vector2(1f, 1f),
            SpriteEffects.None,
            0f
        );
    }
    
    public void Update(GameTime gameTime, int topLeftCornerX, int topLeftCornerY, int bottomRightCornerX, int bottomRightCornerY)
    {
        TopLeftCornerX = topLeftCornerX;
        TopLeftCornerY = topLeftCornerY;
        BottomRightCornerX = bottomRightCornerX;
        BottomRightCornerY = bottomRightCornerY;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        DrawTopLeftSlice(Sprite, spriteBatch);
        DrawTopCenterSlice(Sprite, spriteBatch);
        DrawTopRightSlice(Sprite, spriteBatch);
        
        DrawMiddleLeftSlice(Sprite, spriteBatch);
        DrawMiddleCenterSlice(Sprite, spriteBatch);
        DrawMiddleRightSlice(Sprite, spriteBatch);
        
        DrawBottomLeftSlice(Sprite, spriteBatch);
        DrawBottomCenterSlice(Sprite, spriteBatch);
        DrawBottomRightSlice(Sprite, spriteBatch);
    }
}