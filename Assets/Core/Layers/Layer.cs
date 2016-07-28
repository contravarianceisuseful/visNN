using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

public class Layer : MonoBehaviour
{
    public List<Neuron> Neurons;

    public void ConnectToPreviousLayer(Layer previousLayer, System.Random rand)
    {
        foreach (var neuron in Neurons)
        {
            if(neuron.Axons == null) neuron.Axons = new Axons();
            foreach (var prevNeuron in previousLayer.Neurons)
            {
                neuron.Axons[prevNeuron] = NNBUilder.GetRandomWeight(rand);
            }
        }
    }

    public void ChangeLayerColour(Color color)
    {
        foreach (var spriteRenderer in Neurons.Select(x => x.GetComponent<SpriteRenderer>()))
        {
            spriteRenderer.color = color;
        }
    }
}
