using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator anim;

    private float forwardSpeed = 2.5f;

    private float bounceSpeed = 4.5f;

    private bool didFlap;

    public bool isAlive;

    private Button flapButton;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flapClip, diedClip , pointClip;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        isAlive = true;

        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        //lambda fuction to call method
        flapButton.onClick.AddListener(() => FlapBird());

        SetCameraX();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFlap)
            {
                didFlap = false;
                rb.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("flap");
            }

            if(rb.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    public void FlapBird()
    {
        didFlap = true;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    void SetCameraX()
    {
        CameraScript.offSetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }
}
