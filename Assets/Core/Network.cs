using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Network : MonoBehaviour
{

    public GameObject LayerPrefab;
    public GameObject InputNeuronPrefab;
    public GameObject HiddenNeuronPrefab;
    public GameObject OutputNeuronPrefab;

    public Layer InputLayer;
    public Layer OutputLayer;
    public List<Layer> HiddenLayers;

    public void ClearAll()
    {
        if(InputLayer!= null) DestroyImmediate(InputLayer.gameObject);
        if(OutputLayer != null) DestroyImmediate(OutputLayer.gameObject);
        if(HiddenLayers != null) HiddenLayers.ForEach(x => DestroyImmediate(x.gameObject));
    }

    public void Build(int inputs, int outputs, int hiddenLayers, int hiddenLayerWidth, float horSpacing, float vertSpacing, 
        System.Random rand)
    {
        //CLear
        ClearAll();
        //input layer
        int layerNumber = 0;
        InputLayer = CreateLayer(InputNeuronPrefab, layerNumber, inputs, horSpacing, vertSpacing, Color.green);

        //HiddenLayers
        HiddenLayers = new List<Layer>();
        var prevLayer = InputLayer;
        for (int i = 0; i < hiddenLayers; i++)
        {
            var tempLayer = CreateLayer(HiddenNeuronPrefab, ++layerNumber, hiddenLayerWidth, 
                horSpacing, vertSpacing, Color.gray);
            tempLayer.transform.parent = this.gameObject.transform;
            tempLayer.ConnectToPreviousLayer(prevLayer, rand);
            prevLayer = tempLayer;
            HiddenLayers.Add(tempLayer);
        }
        //output
        OutputLayer = CreateLayer(HiddenNeuronPrefab, ++layerNumber, outputs, horSpacing, vertSpacing, Color.red);
        OutputLayer.ConnectToPreviousLayer(prevLayer, rand);

    }

    private Layer CreateLayer(GameObject prefab, int layerNumber, int width, float horSpacing, 
        float vertSpacing, Color color)
    {
        GameObject LayerGo = Instantiate(LayerPrefab);
        LayerGo.transform.parent = transform;
        LayerGo.transform.localPosition = Vector3.zero;
        LayerGo.transform.Translate(-((width - 1) * horSpacing / 2), layerNumber*vertSpacing, 0);
        var layer = LayerGo.GetComponent <Layer>();
        for (int i = 0; i < width; i++)
        {
            var tempNeuron = Instantiate(prefab);
            tempNeuron.transform.parent = LayerGo.transform;
            tempNeuron.transform.localPosition = Vector3.zero;
            tempNeuron.transform.Translate(i* horSpacing, 0, 0);
            layer.Neurons.Add(tempNeuron.GetComponent<Neuron>());
        }
        layer.ChangeLayerColour(color);
        return LayerGo.GetComponent<Layer>();
    }

    public void DoPropagation()
    {
        this.Propagate();
    }

}


