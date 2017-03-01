using UnityEngine;
using System.Collections;

public class PlaceShape : MonoBehaviour
{
    public GameObject shape;
    private RaycastHit hit;
    Ray ray;
    ChooseShape m_chooseShapeScript;

    public GameObject[] ghostShapes;
    private GameObject m_currentGhostShape;
    private Renderer[] m_ghostRenderers;
    private Vector3 ghostSpawn;
    public Material[] ghostMaterials;
    private int layerMask;
    void Start()
    {
        m_chooseShapeScript = GetComponent<ChooseShape>();
        layerMask = 1 << 8;
        ghostSpawn = new Vector3(-10f,0.3f,0f);

        UpdateGhost();
    }

    public void UpdateGhost()
    {
        m_currentGhostShape = ghostShapes[m_chooseShapeScript.shapeInt];
        m_ghostRenderers = m_currentGhostShape.GetComponentsInChildren<Renderer>();
        m_ghostRenderers[1].material = ghostMaterials[m_chooseShapeScript.colourInt];
    }
    
    void Update()
    {
        ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Vector3 position = new Vector3(hit.transform.position.x, hit.transform.position.y + .3f, hit.transform.position.z);
            m_currentGhostShape.transform.position = position;
        }
        else
        {
            m_currentGhostShape.transform.position = ghostSpawn;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shape = m_chooseShapeScript.CurrentShape();
            ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
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
