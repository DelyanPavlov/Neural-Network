using System.Net;
using System.Numerics;

namespace First_NN
{
    internal static class Program
    {
        public static Trainer trainer = new Trainer();

        static void Main(string[] args)
        {
            int inputSize = 6;
            int[] hiddenSize = { 8 };
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
            trainer.network.CalcWeights();

            //Renderer.DrawNetwork(trainer.network);
        }
    }
}