using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTale.Core.Common.ObjectManagement;

internal sealed class ObjectManager
{
    private readonly List<IObject> _objectList = [];
    private ContentManager ContentManager { get; set; }

    internal ObjectManager(ContentManager contentManager, GraphicsDevice graphicsDevice)
    {
        ContentManager = contentManager;
    }

    internal void AddObject(IObject objectInstance)
    {
        _objectList.Add(objectInstance);
    }

    internal void RemoveObject(int gameObjectIndex)
    {
        try
        {
            _objectList.RemoveAt(gameObjectIndex);
            Console.WriteLine($"Destroyed Object in \"{_objectList}\" at Index {gameObjectIndex}.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    internal void RemoveAllObjects()
    {
        _objectList.Clear();
    }

    internal void Initialize()
    {
        foreach (IObject instance in _objectList)
        {
            instance.Initialize();
        }
    }

    internal void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager)
    {
        foreach (IObject instance in _objectList)
        {
            instance.LoadContent(graphicsDevice, contentManager);
        }
    }

    internal void Update(GameTime gameTime)
    {
        foreach (IObject instance in _objectList)
        {
            instance.Update(gameTime);
        }
    }

    internal void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (IObject instance in _objectList)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            instance.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}