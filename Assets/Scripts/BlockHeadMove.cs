using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockHeadMove : MonoBehaviour
{
    public int headType;
    public int colour;
    private Rigidbody m_rigidBody;
    public float speed;
    private Vector3 m_downwards;
    public Transform floorCheck;
	public bool startMoving = false;
    private bool m_moving;
	private RectTransform m_canvasTransform;

	private bool m_colourGet;
	private bool m_shapeGet;

    public float heartFillAmount = 0f;
	void Start ()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_downwards = -Vector3.up;
        m_moving = true;
		m_canvasTransform = GetComponentInChildren<RectTransform> ();
	}

    void Update()
    {
        if(!Physics.Raycast(floorCheck.position, m_downwards,10f))
        {
            print("Nothing below!");
            m_moving = false;
        }
    }
	bool m_pushedOff = true;
	void FixedUpdate ()
    {
		if (m_moving && startMoving) {
			if (m_pushedOff) 
			{
				m_rigidBody.AddRelativeForce (Vector3.forward * speed);
				//m_rigidBody.velocity = Vector3.right * speed;
				m_pushedOff = false;
			}
		}
		else if(!m_moving && startMoving)
        {
            m_rigidBody.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
            if (!Physics.Raycast(floorCheck.position, m_downwards, 10f))
            {
                print("Nothing below!");
                m_moving = false;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
            m_canvasTransform.eulerAngles = new Vector3 (-45, m_canvasTransform.eulerAngles.y + 90f, 0);
            m_moving = true;
			m_pushedOff = true;
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Finish") 
		{
			Destroy (gameObject, 0.5f);
		}

		if (other.gameObject.tag == "Art") 
		{
			ArtInfo artInfo = other.gameObject.GetComponent<ArtInfo> ();
			if (!m_colourGet) {
				if (artInfo.colour == colour) {
					AddHeart ();
					m_colourGet = true;
				}
			}
			if(!m_shapeGet)
			{
				if (artInfo.shape == headType) 
				{
					AddHeart ();
					m_shapeGet = true;
				}
			}

		}
	}

	public Image heartImage;

	void AddHeart()
	{
        heartFillAmount += 0.5f;
		heartImage.fillAmount = heartFillAmount;
	}

}
