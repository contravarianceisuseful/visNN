using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Neuron : MonoBehaviour
{

    public Axons Axons;

    public double CurrentValue;

    public abstract double CalculateOutgoingSignal();

}






