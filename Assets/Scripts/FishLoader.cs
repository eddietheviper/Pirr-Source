using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLoader : MonoBehaviour {

    public Sprite notCollSprite;

    bool finished = true;

	// Use this for initialization
	void Start () {

        //Debug.Log("Fish Loader Start");

	}
	
	// Update is called once per frame
	void Update () {

        if (finished)
        {
            StartCoroutine(Wait());
        }

    }

    void Create()
    {

        //GameObject player = GameObject.Find("Player");
        //player.GetComponent<SpriteRenderer>().sprite = notCollSprite;

        //Debug.Log("Create opened");

        //Debug.Log("Time Passed");

        int spawn = Random.Range(1, 4);

        //Debug.Log("spawn = " + spawn);

        if (spawn == 1)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("prefabs/Fish Left"));
        }
        else if(spawn == 2)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("prefabs/Fish Up"));
        }
        else if(spawn == 3)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("prefabs/Fish Right"));
        }

        finished = true;
    }

    IEnumerator Wait()
    {
        finished = false;

        if (PlayerContoller.score < 25)
        {
            float placeHoldLess = 1.5f;
            yield return new WaitForSeconds(placeHoldLess);
        }
        else if (PlayerContoller.score < 50 && PlayerContoller.score >= 25)
        {
            float placeHold0 = 1f;
            yield return new WaitForSeconds(placeHold0);
        }
        else if (PlayerContoller.score < 100 && PlayerContoller.score >= 50)
        {
            float placeHold1 = 0.75f;
            yield return new WaitForSeconds(placeHold1);
        }
        else
        {
            float placeHold2 = 0.5f;
            yield return new WaitForSeconds(placeHold2);
        }

        

        Create();

    }


}
