using UnityEngine;
using System.Collections;

public class PlaceShape : MonoBehaviour
{
    public GameObject shape;
    private RaycastHit hit;
    Ray ray;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shape = GetComponent<ChooseShape>().CurrentShape();
            ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 position = new Vector3(hit.transform.position.x, hit.transform.position.y + .3f, hit.transform.position.z);
                GameObject clone = Instantiate(shape, position, Quaternion.identity) as GameObject;
                GameObject cloneShape = clone.GetComponentInChildren<Transform>().gameObject;
                cloneShape.GetComponentInChildren<Renderer>().material = GetComponent<ChooseShape>().CurrentMaterial();
            }
        }
    }
}
