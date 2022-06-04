using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public int speed = 30;
    public Text score;
    public Text result;
    public GameObject[] colors ;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        Debug.Log("the len of blocks is "+(colors.Length).ToString());
        // GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        // Debug.Log(ColorUtility.TryParseHtmlString("#0AC742", out color));
        // Debug.Log(Random.ColorHSV());
    }
    float hitfactor(Vector2 racketpos, Vector2 ballpos, float racketwidht)
    {
        return (ballpos.x - racketpos.x) / racketwidht;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            float x = hitfactor(col.transform.position,
                transform.position,
                col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x,1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (col.gameObject.name == "bottom border")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Destroy(gameObject);
            result.text = "GAME OVER";
        }
        else if (!(col.gameObject.name == "top border" || col.gameObject.name == "right border" || col.gameObject.name == "left border"))
        {
            GetComponent<SpriteRenderer>().color = col.gameObject.GetComponent<SpriteRenderer>().color;
            n++;
            score.text = n.ToString();
            Destroy(col.gameObject);
            if (n == colors.Length * 4)
            {
                Destroy(gameObject);
                result.GetComponent<Text>().color = Color.green;
                result.text = "YOU WIN";
            }
        }
    }   
}
