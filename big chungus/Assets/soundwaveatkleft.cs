using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundwaveatkleft : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 20f;
    public float destroytime = 4f;
    //Vector3 theScale;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "bullet" && collider.gameObject.tag != "item")
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        // theScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 pos = transform.position;
        Vector2 movement_vector = new Vector2(0, 0);
        pos.x -= panSpeed * Time.deltaTime;
        transform.localScale += new Vector3(0.0006f, 0.0006f, 0);
        movement_vector.x = panSpeed;
        transform.position = pos;
        destroytime -= Time.deltaTime;
        if (destroytime <= 0)
        {
            Destroy(gameObject);
        }
    }
}