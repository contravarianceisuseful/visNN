using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Axons : Dictionary<Neuron, Axon>
{

    public double SumIncomingValues()
    {
        return this.Values.Select(x => x.Weight).Sum();
    }

}

public class Axon
{
    private double _weight;
    public LineRenderer Line;

    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value != _weight)
            {
                _weight = value;
                ChangeLineWidth(_weight);
            }  
        }
    }

    public static float LineScale = 0.6f;
    public static float LineLogScale = 0.5f;
    public static float MaxWidth = 5; //TODO move to NNBuilder

    private void ChangeLineWidth(double weight)
    {
        float width = 0;
        if (weight != 0)
        {
            width = Math.Min(LineScale * (Mathf.Log10(LineLogScale * Mathf.Abs((float)weight)) + 1), MaxWidth);
        }
        Line.SetWidth(width, width);
        //TODO fix colors by adding materials
        if(weight < 0) Line.SetColors(Color.red, Color.red);
    }

}