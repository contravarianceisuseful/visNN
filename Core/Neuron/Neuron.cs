using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class Neuron : MonoBehaviour
{
    private Axons Axons;

    private Dictionary<Neuron, GameObject> AxonLines;

    private double _currentValue;

    public double CurrentValue
    {
        get
        {
            return _currentValue;
        }
        set
        {
            _currentValue = value;
            GetComponentInChildren<TextMesh>().text = Math.Round(_currentValue, 4).ToString();
        }
    }

    public abstract double CalculateOutgoingSignal();


    //Axon Dict helpers
    public void InstantiateAxonDict()
    {
        if (Axons == null)
        {
            Axons = new Axons();
        }
    }

    public void AddAxon(Neuron neuron)
    {
        Axons.Add(neuron, new Axon());
        Axons[neuron].Line = Instantiate(NNBUilder.AxonPrefabRef).GetComponent<LineRenderer>();
        Axons[neuron].Line.SetPosition(0, this.transform.position);
        Axons[neuron].Line.SetPosition(1, neuron.transform.position);
        Axons[neuron].Line.transform.SetParent(this.transform);
    }

    public void ChangeWeight(Neuron neuron, double newWeight)
    {
        Axons[neuron].Weight = newWeight;
    }

    public double GetWeight(Neuron axite)
    {
        if(!Axons.ContainsKey(axite)) throw new Exception("Can't retrieve weight as not contain this axite");
        return Axons[axite].Weight;
    }

    public List<Neuron> GetAxites()
    {
        return new List<Neuron>(Axons.Keys);
    }

    public bool HasAxite(Neuron axite)
    {
        return Axons.ContainsKey(axite);
    }
    
}






