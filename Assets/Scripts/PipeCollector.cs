using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour {


    private GameObject[] pipeHolders;
    private float distance = 3.5f;
    private float lastPIPX;
    private float pipeMin = -2f;
    private float pipeMax = 2.8f;

    // Use this for initialization
    void Awake () {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for (int i =0;i < pipeHolders.Length;i++)
        {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }


        lastPIPX = pipeHolders[0].transform.position.x;

        for (int i = 0; i < pipeHolders.Length; i++) 
        {
            if (lastPIPX < pipeHolders[i].transform.position.x)
            {
                lastPIPX = pipeHolders[i].transform.position.x;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PipeHolder")
        {
            Vector3 temp = collision.transform.position;

            temp.x = lastPIPX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            collision.transform.position = temp;

            lastPIPX = temp.x;
        }
        
    }
}
