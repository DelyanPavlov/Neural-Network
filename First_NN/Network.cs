using System;
using System.Collections.Generic;
using System.Text;

namespace First_NN
{
    internal class Network
    {
        public List<List<Neuron>> layers = new List<List<Neuron>>();

        public void CalcWeights()
        {
            for (int j = 1; j < layers.Count; j++)
            {
                for (int i = 0; i < layers[j].Count; i++)
                {
                    layers[j][i].calcWeight(layers[j - 1]);
                }
            }
        }

        public void InitNetwork(int inputSize, int[] hiddenSize, int outputSize)
        {
            List<Neuron> Input = new List<Neuron>();
            List<Neuron> Hidden1 = new List<Neuron>();
            List<Neuron> Output = new List<Neuron>();
            Random rand = new Random();
            for (int i = 0; i < inputSize; i++)
            {
                Input.Add(new Neuron(1));
            }

            for (int i = 0; i < hiddenSize[0]; i++)
            {
                List<double> tempWeights = new List<double>();
                List<double> tempBiases = new List<double>();
                for (int j = 0; j < inputSize; j++)
                {
                    tempWeights.Add(rand.NextDouble());
                    tempBiases.Add(rand.NextDouble());
                }
                Hidden1.Add(new Neuron(tempWeights, tempBiases, 0));
            }

            for (int i = 0; i < outputSize; i++)
            {
                List<double> tempWeights = new List<double>();
                List<double> tempBiases = new List<double>();
                for (int j = 0; j < hiddenSize[0]; j++)
                {
                    tempWeights.Add(rand.NextDouble());
                    tempBiases.Add(rand.NextDouble());
                }
                Output.Add(new Neuron(tempWeights, tempBiases, 0));
            }

            layers.Add(Input);
            layers.Add(Hidden1);
            layers.Add(Output);
        }
    }
}
