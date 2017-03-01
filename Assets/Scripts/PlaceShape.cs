using UnityEngine;
using System.Collections;

public class PlaceShape : MonoBehaviour
{
    public GameObject shape;
    private RaycastHit hit;
    Ray ray;
    ChooseShape m_chooseShapeScript;

    public GameObject cubeGhost;
    public Renderer cubeGhostRender;
    private Vector3 ghostSpawn;
    public Material[] ghostMaterials;
    private int layerMask;
    void Start()
    {
        m_chooseShapeScript = GetComponent<ChooseShape>();
        layerMask = 1 << 8;
        ghostSpawn = cubeGhost.transform.position;

        UpdateGhostColour();
    }

    public void UpdateGhostColour()
    {
        cubeGhostRender.material = ghostMaterials[m_chooseShapeScript.colourInt];
    }
    
    void Update()
    {
        ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Vector3 position = new Vector3(hit.transform.position.x, hit.transform.position.y + .3f, hit.transform.position.z);
            cubeGhost.transform.position = position;
        }
        else
        {
            cubeGhost.transform.position = ghostSpawn;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shape = m_chooseShapeScript.CurrentShape();
            ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 position = new Vector3(hit.transform.position.x, hit.transform.position.y + .3f, hit.transform.position.z);
                GameObject clone = Instantiate(shape, position, Quaternion.identity) as GameObject;
                Renderer[] cloneShapes = clone.GetComponentsInChildren<Renderer>();
                clone.GetComponentInChildren<ArtInfo>().colour = m_chooseShapeScript.colourInt;
                clone.GetComponentInChildren<ArtInfo>().shape = m_chooseShapeScript.shapeInt;
                cloneShapes[1].GetComponentInChildren<Renderer>().material = GetComponent<ChooseShape>().CurrentMaterial();
            }
        }
    }
}
