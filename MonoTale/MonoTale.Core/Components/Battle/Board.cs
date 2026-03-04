using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTale.Core.Common.UI;
using MonoTale.Core.Common.ObjectManagement;

namespace MonoTale.Core.Components.Battle;

internal class Board: IObject
{
    /*
     * TODO: Add a RenderTarget inside the Board to be able to clip content outside of it.
     */
    private int CurrentTopLeftCornerX { get; set; }
    private int CurrentTopLeftCornerY { get; set; }
    private int CurrentBottomRightCornerX { get; set; }
    private int CurrentBottomRightCornerY { get; set; }

    private int TargetTopLeftCornerX { get; set; }
    private int TargetTopLeftCornerY { get; set; }
    private int TargetBottomRightCornerX { get; set; }
    private int TargetBottomRightCornerY { get; set; }

    private int ResizeAnimationSpeed { get; set; }
    private Texture2D Sprite { get; set; }
    private NineSliceTiledTexture2D NineSliceTiledSprite { get; set; }
    private Color SpriteColor { get; set; }

    internal Board
    (
    int currentTopLeftCornerX,
    int currentTopLeftCornerY,
    int bottomRightCornerX,
    int bottomRightCornerY
    )
    {
        CurrentTopLeftCornerX = currentTopLeftCornerX;
        CurrentTopLeftCornerY = currentTopLeftCornerY;

        CurrentBottomRightCornerX = bottomRightCornerX;
        CurrentBottomRightCornerY = bottomRightCornerY;
    }

    private int ResizePart(int currentValue, int targetValue, int resizeAnimationSpeed)
    {
        if (currentValue <= targetValue)
        {
            currentValue += resizeAnimationSpeed;
            if (currentValue >= targetValue)
            {
                currentValue = targetValue;
            }
        }

        if (currentValue >= targetValue)
        {
            currentValue -= resizeAnimationSpeed;
            if (currentValue <= targetValue)
            {
                currentValue = targetValue;
            }
        }
        return currentValue;
    }

    private void SetSize(int newTargetTopLeftCornerX, int newTargetTopLeftCornerY, int newTargetBottomRightCornerX, int newTargetBottomRightCornerY)
    {

    }
    
    public void Initialize()
    {
        CurrentTopLeftCornerX = 16;
        CurrentTopLeftCornerY = 124;
        CurrentBottomRightCornerX = 303;
        CurrentBottomRightCornerY = 193;
        
        TargetTopLeftCornerX = CurrentTopLeftCornerX + 64;
        TargetTopLeftCornerY = 32;
        TargetBottomRightCornerX = CurrentBottomRightCornerX - 64;
        TargetBottomRightCornerY = 193;
        
        ResizeAnimationSpeed = 8;
        
        SpriteColor = Color.White;
        
        NineSliceTiledSprite = new(Sprite, CurrentTopLeftCornerX, CurrentTopLeftCornerY, CurrentBottomRightCornerX, CurrentBottomRightCornerY);
    }

    public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager)
    {
        Sprite = contentManager.Load<Texture2D>("MGSPR_BattleBoardSliceable");
    }

    public void UnloadContent()
    {
        
    }

    public void Update(GameTime gameTime)
    {
        NineSliceTiledSprite.Update(gameTime, CurrentTopLeftCornerX, CurrentTopLeftCornerY, CurrentBottomRightCornerX, CurrentBottomRightCornerY);
        
        CurrentTopLeftCornerX = ResizePart(CurrentTopLeftCornerX, TargetTopLeftCornerX, ResizeAnimationSpeed);
        CurrentTopLeftCornerY = ResizePart(CurrentTopLeftCornerY, TargetTopLeftCornerY, ResizeAnimationSpeed);

        CurrentBottomRightCornerX = ResizePart(CurrentBottomRightCornerX, TargetBottomRightCornerX, ResizeAnimationSpeed);
        CurrentBottomRightCornerY = ResizePart(CurrentBottomRightCornerY, TargetBottomRightCornerY, ResizeAnimationSpeed);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        NineSliceTiledSprite.Draw(gameTime, spriteBatch);
    }
}