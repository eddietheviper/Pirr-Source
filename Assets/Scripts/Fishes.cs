using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishes : MonoBehaviour {

    //Vector2 move = new Vector2(0.1f,0f);
    //float speed = 0;

    public Sprite collSprite;
    public Sprite notCollSprite;

    // Use this for initialization
    void Start () {

        int thisVel = PlayerContoller.score;

        if (this.tag == "FishL")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((thisVel * 0.2f) + 2f, 0f);
        }
        else if (this.tag == "FishR")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-((thisVel * 0.2f) + 2f), 0f);
        }
        else if (this.tag == "FishU")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -((thisVel * 0.2f) + 2f));
        }

        GameObject player = GameObject.Find("Player");
        player.GetComponent<SpriteRenderer>().sprite = notCollSprite;

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject player = GameObject.Find("Player");

        PlayerContoller pc = gameObject.AddComponent(typeof(PlayerContoller)) as PlayerContoller;

        AudioSource aS = GameObject.Find("Audio Explosion").GetComponent<AudioSource>();

        //Debug.Log(coll.name);

        if (coll.name == "Left Coll")
        {
            if (PlayerContoller.facing == 1)
            {
                Destroy(this.gameObject);
                PlayerContoller.score++;
                aS.Play();
                //pc.explode();
            }
        }

        if (coll.name == "Up Coll")
        {
            if (PlayerContoller.facing == 2)
            {
                Destroy(this.gameObject);
                PlayerContoller.score++;
                aS.Play();
                //pc.explode();
            }
        }

        if (coll.name == "Right Coll")
        {
            if (PlayerContoller.facing == 3)
            {
                Destroy(this.gameObject);
                PlayerContoller.score++;
                aS.Play();
                //pc.explode();
            }
        }

        if(coll.name == "Player")
        {
            //Debug.Log("Player Hit");
            SceneManager.LoadScene("Game_Over");
        }

    }

}
