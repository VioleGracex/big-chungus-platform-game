using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrotbulletleft : MonoBehaviour {

    public float panSpeed = 20f;
    public float destroytime = 6f;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag!="player" && collider.gameObject.tag != "bullet" && collider.gameObject.tag != "item")
        {
            Destroy(gameObject);
        }
      
    }
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("big-chungus");
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        Vector2 movement_vector = new Vector2(0, 0);
        pos.x -= panSpeed * Time.deltaTime;
        movement_vector.x = panSpeed;
        transform.position = pos;
        destroytime -= Time.deltaTime;
        if (destroytime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

