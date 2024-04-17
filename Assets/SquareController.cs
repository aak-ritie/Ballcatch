
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circle;
    public GameObject upScore;
    public Transform parent;
    public Text scoreText;
    public GameObject gameOverPanel;
    private int score;
    public Text addScore;
    public bool isAlive= true;
    
    public enum CircleType
    {
        Red,
        Blue,
        Green,
        Black
        
    }
    public CircleType circleType;
    
    void Start()
    {
        score = 0;
        StartCoroutine(SpawnBall());
        //InvokeRepeating("SpawnBall", 0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetKey(KeyCode.LeftArrow) && isAlive)
        {
            transform.Translate(Vector2.left * 10 * Time.deltaTime);
        }
       else  if (Input.GetKey(KeyCode.RightArrow) && isAlive)
        {
            transform.Translate(Vector2.right * 10 * Time.deltaTime);
        }
        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        if ((collision.transform.CompareTag("circle")) && isAlive)
        {
            // collision.gameObject.SetActive(false);
            // score += 1;
            // scoreText.text=score.ToString();

            //// circle.transform.position = new Vector2(Random.Range(-8, 8), 4.31f);

            // GameObject ball = Instantiate(circle, parent);
            // ball.transform.position = new Vector2(Random.Range(-8, 8), 4.31f);
            // ball.SetActive(true);
            
            if (circleType == CircleType.Red )
            {
                score += 1;
                addScore.text = "+1";
            }
            else if (circleType == CircleType.Blue )
            {
                score += 2;
                addScore.text = "+2";
            }
            else if (circleType == CircleType.Green )
            {
                score += 3;
                addScore.text = "+3";
            }
            else if (circleType == CircleType.Black)
            {
               isAlive = false;
               GameOver();

               upScore.SetActive(false);
            }
            collision.gameObject.SetActive(false);

            scoreText.text = score.ToString();

        }
        
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    //Function to pause the game
   


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator SpawnBall()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject ball = Instantiate(circle, parent);
            circleType = (CircleType)Random.Range(0, 4);
            if (circleType == CircleType.Red)
            {
                ball.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (circleType == CircleType.Blue)
            {
                ball.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (circleType == CircleType.Green)
            {
                ball.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (circleType == CircleType.Black)
            {
                ball.GetComponent<SpriteRenderer>().color = Color.black;
            }
            ball.transform.position = new Vector2(Random.Range(-8, 8), 4.31f);
            ball.SetActive(true);
        }

    }


    //public void SpawnBall()
    //{
    //        GameObject ball = Instantiate(circle, parent);
    //        circleType = (CircleType)Random.Range(0, 4);
    //        if (circleType == CircleType.Red)
    //        {
    //            ball.GetComponent<SpriteRenderer>().color = Color.red;
    //        }
    //        else if (circleType == CircleType.Blue)
    //        {
    //            ball.GetComponent<SpriteRenderer>().color = Color.blue;
    //        }
    //        else if (circleType == CircleType.Green)
    //        {
    //            ball.GetComponent<SpriteRenderer>().color = Color.green;
    //        }
    //        else if (circleType == CircleType.Black)
    //        {
    //            ball.GetComponent<SpriteRenderer>().color = Color.black;
    //        }
    //        ball.transform.position = new Vector2(Random.Range(-8, 8), 4.31f);
    //        ball.SetActive(true);
        
    //}
}
