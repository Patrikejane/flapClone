using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public static float offSetX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {
                MoveCamera();
            }
        }
            
	}

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        temp.x = BirdScript.instance.GetPositionX() + offSetX;
        transform.position = temp;
    }
}
