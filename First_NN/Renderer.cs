using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace First_NN
{
    internal static class Renderer
    {
        public static int windowWidth = 1280, windowHeight = 720;
        public static int NNDisplayW = windowWidth / 3, NNDisplayH = windowHeight / 3;

        public static bool InitWindow()
        {
            try
            {
                Raylib.InitWindow(windowWidth, windowHeight, "Neural network");
            }
            catch
            {
                Raylib.CloseWindow();
                return false;
            }
            MainLoop();
            return true;
        }

        private static void MainLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Program.Update();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        public static void DrawTrainer(Trainer trainers)
        {
            
        }

        public static void DrawNetwork(Network network)
        {
            Vector2 neuronPos = new Vector2();

            for (int i = 0; i < network.layers.Count; i++)
            {
                for (int j = 0; j < network.layers[i].Count; j++)
                {
                    neuronPos.X = NNDisplayW / (network.layers.Count + 1) * (i + 1);
                    neuronPos.Y = NNDisplayH / (network.layers[i].Count + 1) * (j + 1);
                    Raylib.DrawCircle((int)neuronPos.X, (int)neuronPos.Y, 7, Color.Red);
                    Raylib.DrawText($"{network.layers[i][j].val:f2}", (int)neuronPos.X, (int)neuronPos.Y, 7, Color.White);
                }
            }
        }
    }
}
