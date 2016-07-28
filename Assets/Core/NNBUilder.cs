using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class NNBUilder : MonoBehaviour
{

    public int Inputs;
    public int HiddenLayers;
    public int HiddenLayerWidth;
    public int Outputs;

    public float HorSpacing;
    public float VertSpacing;

    public Network Network;

    public void BuildNeuralNetwork()
    {
        Network.Build(Inputs, Outputs, HiddenLayers, HiddenLayerWidth, HorSpacing, VertSpacing, new System.Random());
    }

    public static double GetRandomWeight(System.Random rand)
    {
        if(rand == null) return new System.Random().NextDouble();
        return rand.NextDouble();
    }

    public static double GetRandomWeight(System.Random rand, int lowerBound, int upperBound)
    {
        return rand.Next(lowerBound,upperBound);
    }
}

[CustomEditor(typeof(NNBUilder))]
class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Build"))
        {
            var builder = target as NNBUilder;
            builder.Network.Build(builder.Inputs, builder.Outputs,
                builder.HiddenLayers, builder.HiddenLayerWidth, builder.HorSpacing, builder.VertSpacing, new System.Random());
        };

    }
}
