using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace First_NN
{
    internal class Trainer
    {
        public Network network = new Network();
        public Vector2 playerPos;
        public Vector2 finishPos;

        public void InitTrainer(Vector2 playerPos, Vector2 finishPos, int inputSize, int[] hiddenSize, int outputSize)
        {
            network.InitNetwork(inputSize, hiddenSize, outputSize);
            this.playerPos = playerPos;
            this.finishPos = finishPos;
        }

    }
}
