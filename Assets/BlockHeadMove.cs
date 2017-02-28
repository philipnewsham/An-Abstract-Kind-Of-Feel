using UnityEngine;
using System.Collections;

public class BlockHeadMove : MonoBehaviour
{
    public int headType;
    public int colour;
    private Rigidbody m_rigidBody;
    public float speed;
    private Vector3 m_downwards;
    public Transform floorCheck;

    private bool m_moving;
	void Start ()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_downwards = -Vector3.up;
        m_moving = true;
	}

    void Update()
    {
        if(!Physics.Raycast(floorCheck.position, m_downwards,10f))
        {
            print("Nothing below!");
            m_moving = false;
        }
    }
	
	void FixedUpdate ()
    {
        if (m_moving)
            m_rigidBody.AddRelativeForce(Vector3.forward * speed);
        else
        {
            m_rigidBody.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
            m_moving = true;
        }
	}
}
