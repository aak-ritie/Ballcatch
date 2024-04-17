using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    public int currentHealth = 0;
    public SquareController squareController;
    public int maxHealth = 100;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("circle")))
        {
        Destroy(collision.gameObject);
        TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        if((squareController.isAlive)&&(squareController.circleType!=SquareController.CircleType.Black))
        {
            currentHealth -= damage;
            if (currentHealth == 0)
            {
                squareController.isAlive = false;
                squareController.GameOver();

            }
        }
       
       
    }


}
