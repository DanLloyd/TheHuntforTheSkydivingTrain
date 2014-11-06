using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;


namespace TheHuntforTheSkydivingTrain
{
	public class AppMain
	{
		//GraphicsContext required for graphics, acts as a graphics 'instance'
		private static GraphicsContext graphics;
		private static Texture2D backgroundTexture;
		private static Texture2D spaceshipTexture;
		private static Sprite background;
		private static Sprite spaceship;
		
		
		public static void Main (string[] args)
		{
			Initialize();
			
			
			//Game Loop
			while (true) 
			{
				SystemEvents.CheckEvents();
				Update ();
				Render ();
			}
		}

		public static void Initialize()
		{
			// Set up the graphics system
			graphics = new GraphicsContext();
			
			//Load in spaceship
			spaceshipTexture = new Texture2D("/Application/Assets/spikedShip.png", false);
			
			spaceship = new Sprite(graphics, spaceshipTexture);
			spaceship.Position.X = 50;
			spaceship.Position.Y = 50;
			
			//NOTE: Screen size for PSVITA = 960x544
			backgroundTexture = new Texture2D("/Application/Assets/background.png", false);
			
			background = new Sprite(graphics, backgroundTexture);
			background.Position.X = 0;
			background.Position.Y = 0;
			
			

		}

		public static void Update()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
		}

		public static void Render()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear();
			
			//need to call Render() on each Sprite
			background.Render();
			spaceship.Render();

			// Present the screen
			graphics.SwapBuffers();
		}
	}
}
