using System.Net;
using System.Numerics;

namespace First_NN
{
    internal static class Program
    {
        public static Trainer trainer = new Trainer();
        public static double distFinish;

        static void Main(string[] args)
        {
            int inputSize = 3;
            int[] hiddenSize = { 1 };
            int outputSize = 2;

            trainer.InitTrainer(new Vector2(0.1f), new Vector2(0.9f), inputSize, hiddenSize, outputSize);

            if (Renderer.InitWindow())
            {
                Console.WriteLine("Window initialization failed!");
            }

        }

        //Called once each frame
        public static void Update()
        {
            Thread.Sleep(20);
            distFinish = Math.Sqrt(Math.Pow(Math.Abs(trainer.playerPos.X - trainer.finishPos.X), 2) 
                + Math.Pow(Math.Abs(trainer.playerPos.Y - trainer.finishPos.Y), 2));
            trainer.network.layers[0][0] = new Neuron(trainer.playerPos.X * 2 - 1);
            trainer.network.layers[0][1] = new Neuron(trainer.playerPos.Y * 2 - 1);
            trainer.network.layers[0][2] = new Neuron(distFinish);
            trainer.network.CalcWeights();

            trainer.playerPos.X += (float)trainer.network.layers[2][0].val / 100;
            trainer.playerPos.Y += (float)trainer.network.layers[2][1].val / 100;

            Renderer.DrawTrainer(trainer);
            Renderer.DrawNetwork(trainer.network);
        }
    }
}