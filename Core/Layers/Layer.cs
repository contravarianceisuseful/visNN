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
            neuron.InstantiateAxonDict();
            foreach (var prevNeuron in previousLayer.Neurons)
            {
                neuron.AddAxon(prevNeuron);
                neuron.ChangeWeight(prevNeuron, NNBUilder.GetRandomWeight(rand));
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
