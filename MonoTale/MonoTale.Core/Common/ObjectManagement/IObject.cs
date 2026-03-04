using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTale.Core.Common.ObjectManagement;

public interface IObject
{
    internal void Initialize();

    internal void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager);

    internal void UnloadContent();

    internal void Update(GameTime gameTime);

    internal void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}