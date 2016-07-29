using UnityEngine;
using System.Collections;

public static class PropogatorHelper
{
    /// <summary>
    /// Calculates the outputs from current values in inputs
    /// </summary>
    /// <param name="network"></param>
    public static void Propagate(this Network network)
    {
        Debug.Log("propagated!");
        foreach (Layer hiddenLayer in network.HiddenLayers)
        {
            hiddenLayer.CalculateLayerValues();
        }
        network.OutputLayer.CalculateLayerValues();
    }

    public static void CalculateLayerValues(this Layer layer)
    {
        foreach (var neuron in layer.Neurons)
        {
            neuron.CurrentValue = 0;
            foreach (var axite in neuron.GetAxites())
            {
                neuron.CurrentValue += axite.CalculateOutgoingSignal() * neuron.GetWeight(axite);
            }
        }
    }
}
