using UnityEngine;
using System.Collections;

public class HiddenNeuron : Neuron
{
    public override double CalculateOutgoingSignal()
    {
        return CurrentValue >= 1 ? 1 : 0;
    }
}