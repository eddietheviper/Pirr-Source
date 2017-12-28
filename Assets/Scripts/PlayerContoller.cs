using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

    public static int facing;
    public static int score;

    public Text textBox;

    //public AudioClip impact;
    //AudioSource audioSource;

    private Quaternion facingUp = Quaternion.Euler(new Vector3(0, 0, 90));
    private Quaternion facingRight = Quaternion.Euler(new Vector3(0, 0, 0));
    private Quaternion facingLeft = Quaternion.Euler(new Vector3(0, 0, 180));

    // Use this for initialization
    void Start () {

        GameObject.Find("Left Coll").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Up Coll").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Right Coll").GetComponent<SpriteRenderer>().enabled = false;

        score = 0;
        facing = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            facing = 3;
            faceTo(facingRight, facing);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facing = 1;
            faceTo(facingLeft, facing);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            facing = 2;
            faceTo(facingUp, facing);
        }

        Score();

    }

    private void Score()
    {
        textBox.text = "Score: " + score;
    }

    void faceTo(Quaternion face, int sprite)
    {
        this.gameObject.GetComponent<Transform>().rotation = face;

        if(sprite == 1)
        {
            //Debug.Log(sprite);
            GameObject.Find("Left Coll").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Up Coll").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Right Coll").GetComponent<SpriteRenderer>().enabled = false;
        }else if(sprite == 2)
        {
            //Debug.Log(sprite);
            GameObject.Find("Left Coll").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Up Coll").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Right Coll").GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            //Debug.Log(sprite);
            GameObject.Find("Left Coll").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Up Coll").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Right Coll").GetComponent<SpriteRenderer>().enabled = true;
        }

    }

}
