using System;
using UnityEngine;
using System.Collections;

public class OutputNeuron : MonoBehaviour {

    public class OutpuNeuron : Neuron
    {
        public override double CalculateOutgoingSignal()
        {
            throw new Exception("Outgoing signal should not be called because the output neuron has no higher layers");
        }
    }
}
