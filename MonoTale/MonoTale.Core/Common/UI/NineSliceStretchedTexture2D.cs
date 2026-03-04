using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTale.Core.Common.UI;

internal sealed class NineSliceStretchedTexture2D
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

    internal NineSliceStretchedTexture2D(Texture2D sprite, int topLeftCornerX, int topLeftCornerY,
        int bottomRightCornerX, int bottomRightCornerY)
    {
        Sprite = sprite;

        TopLeftCornerX = topLeftCornerX;
        TopLeftCornerY = topLeftCornerY;
        BottomRightCornerX = bottomRightCornerX;
        BottomRightCornerY = bottomRightCornerY;

        const int sliceCount = 9;

        SpriteSlicePositions = new Vector2[sliceCount];
    }
}