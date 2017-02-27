using UnityEngine;
using System.Collections;

public class ChooseShape : MonoBehaviour {
    public GameObject[] shapes;
    public GameObject currentShape;
    private int m_currentShapeNo;
    public Material[] materials;
    public Material currentMaterial;
    
    void Start()
    {
        ChooseCurrentShape(0);
        ChooseCurrentColour(0);
    }
    public void ChooseCurrentShape(int shapeNo)
    {
        m_currentShapeNo = shapeNo;
        currentShape = shapes[m_currentShapeNo];
    }

    public void ChooseCurrentColour(int colourNo)
    {
        currentMaterial = materials[colourNo];
    }

    public Material CurrentMaterial()
    {
        return currentMaterial;
    }

    public GameObject CurrentShape()
    {
        return currentShape;
    }


}
