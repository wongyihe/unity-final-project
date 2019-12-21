using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private Transform main1;
    private Transform main2;
    private float h;
    private float v;
    private int score=0;
   public AudioClip aud_clip;
    private AudioSource aud_sou;
	// Use this for initialization
	void Start () {
        main1 = this.transform;
        main2 = GameObject.Find("Sphere002").transform;
        aud_sou = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
       // Debug.Log(h);
        main1.Translate(new Vector3(0, v*10*Time.deltaTime, -10 * Time.deltaTime));
        main1.Rotate(new Vector3(0, h * 45 * Time.deltaTime, 0));
        main2.Rotate(new Vector3(0,0, 360* Time.deltaTime));
	}
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "coin")
        {
            Destroy(col.gameObject);
            score++;
            aud_sou.PlayOneShot(aud_clip);
            Debug.Log("score=" + score);
        }
    }
}
