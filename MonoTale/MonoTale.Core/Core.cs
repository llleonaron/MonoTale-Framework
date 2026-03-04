using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTale.Core.Components.Battle;
using MonoTale.Core.Common.ObjectManagement;

namespace MonoTale.Core;

/// <summary>
/// The main class for the game, responsible for managing game components and settings.
/// </summary>
public class Core: Game
{
    // Resources for drawing.
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    private RenderTarget2D _internalGameRenderer;
    private SpriteBatch _spriteBatch;
    private readonly ObjectManager _objectManager;
    
    /// <summary>
    /// Initializes a new instance of the game.
    /// </summary>
    public Core()
    {
        _graphicsDeviceManager = new GraphicsDeviceManager(this);
        _objectManager = new(Content, GraphicsDevice);

        // Share GraphicsDeviceManager as a service.
        Services.AddService(typeof(GraphicsDeviceManager), _graphicsDeviceManager);

        Content.RootDirectory = "Content";

        IsFixedTimeStep = true;
        TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 30.0);
        _graphicsDeviceManager.IsFullScreen = false; 
    }

    /// <summary>
    /// Initializes the game, including setting up localization.
    /// </summary>
    protected override void Initialize()
    {
        const int idealWidth = 320;
        const int idealHeight = 240;

        const int windowScaleFactor = 3;
        _graphicsDeviceManager.PreferredBackBufferWidth = (idealWidth * windowScaleFactor);
        _graphicsDeviceManager.PreferredBackBufferHeight = (idealHeight * windowScaleFactor);
        _graphicsDeviceManager.ApplyChanges();

        base.Initialize();

        _objectManager.Initialize();
    }

    /// <summary>
    /// Loads game content, such as textures and audio.
    /// </summary>
    protected override void LoadContent()
    {
        base.LoadContent();

        _internalGameRenderer = new RenderTarget2D(GraphicsDevice, 320, 240);

        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        var objBattleBoard = new Board(0, 0, 0, 0);
        var objBattleHeart = new Heart(160, 160, 0);
        
        _objectManager.AddObject(objBattleBoard);
        _objectManager.AddObject(objBattleHeart);
        
        _objectManager.LoadContent(GraphicsDevice, Content);
    }

    /// <summary>
    /// Updates the game's logic, called once per frame.
    /// </summary>
    /// <param name="gameTime">
    /// Provides a snapshot of timing values used for game updates.
    /// </param>
    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        _objectManager.Update(gameTime);
    }

    /// <summary>
    /// Draws the game's graphics, called once per frame.
    /// </summary>
    /// <param name="gameTime">
    /// Provides a snapshot of timing values used for rendering.
    /// </param>
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        GraphicsDevice.SetRenderTarget(_internalGameRenderer);

        GraphicsDevice.Clear(Color.Black);

        _objectManager.Draw(gameTime, _spriteBatch);

        GraphicsDevice.SetRenderTarget(null);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_internalGameRenderer, GraphicsDevice.Viewport.Bounds, Color.White);
        _spriteBatch.End();
    }
}