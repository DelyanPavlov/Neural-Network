using System;
using System.Collections.Generic;
using System.Text;

namespace First_NN;

public class Neuron
{
    public List<double> weights = new List<double>();
    public List<double> biases = new List<double>();
    public double val;

    public Neuron(List<double> newWeights, List<double> newBiases, double val)
    {
        weights = newWeights;
        biases = newBiases;
        this.val = val;
    }

    public Neuron(double value)
    {
        val = Helper.Sigmoid(value);
    }

    public void calcWeight(List<Neuron> prevLayer)
    {
        val = 0;
        for (int i = 0; i < prevLayer.Count; i++)
        {
            val += prevLayer[i].val * weights[i] + biases[i];
        }
        val = Helper.Sigmoid(val);
    }
}
