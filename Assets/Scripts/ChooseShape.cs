using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChooseShape : MonoBehaviour {
    public GameObject[] shapes;
    public GameObject currentShape;
    private int m_currentShapeNo;
    public Material[] materials;
    public Material currentMaterial;

	public Color32[] buttonColours;
	public Image[] buttons;

    public int shapeInt;
    public int colourInt;
    void Start()
    {
        ChooseCurrentShape(0);
        ChooseCurrentColour(0);
    }
    public void ChooseCurrentShape(int shapeNo)
    {
        m_currentShapeNo = shapeNo;
        shapeInt = shapeNo;
        currentShape = shapes[m_currentShapeNo];
    }

    public void ChooseCurrentColour(int colourNo)
    {
        currentMaterial = materials[colourNo];
        colourInt = colourNo;
		for (int i = 0; i < 3; i++)
		{
			buttons [i].color = buttonColours [colourNo];
		}

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
