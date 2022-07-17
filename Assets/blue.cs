using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    //player 1
    public PlayerControl player1;
    //player 2
    public PlayerControl player2;

    // ketika terjadi tumbukan dengan bola dapatkan bonus score    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            var direction = transform.InverseTransformPoint(collision.transform.position);

            if (direction.x > 0f)
            {
                player2.BlueScore();
            }
            else if (direction.x < 0f)
            {
                player1.BlueScore();
            }
            Destroy(this.gameObject);
        }
    }
}
