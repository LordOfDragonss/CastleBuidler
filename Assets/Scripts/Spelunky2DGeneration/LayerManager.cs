using System;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public static LayerManager Instance { get; private set; }
    public int CurrentLayer = 0;
    public List<Layer> layers;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Layer GetLayer(int LayerNumber)
    {
        Layer layer = layers.Find(n=>n.LayerNumber == LayerNumber);
        if(layer != null) return layer;
        else return null;
    }

    public void NextLayer()
    {
        CurrentLayer++;
    }

    public void PreviousLayer()
    {
        CurrentLayer--;
    }

    public int GetCurrentLayerSeed()
    {
        Layer layer = GetLayer(CurrentLayer);
        return layer.seed;
    }

    public bool IsNewLayer(int number)
    {
        if(GetLayer(number) == null)
            return true;
        else return false;
    }

}

[Serializable]
public class Layer
{
    public int LayerNumber;
    public int seed;

    public Layer(int layerNumber, int seed)
    {
        LayerNumber = layerNumber;
        this.seed = seed;
    }
}
