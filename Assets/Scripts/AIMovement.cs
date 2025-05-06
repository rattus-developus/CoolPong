using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float maxMove;
    [SerializeField] Transform ball;

    void Update()
    {
        int move = 0;

        if(ball.GetComponent<BallMovement>().isGoingRight())
        {
            if(ball.position.y > transform.position.y) move++;
            if(ball.position.y < transform.position.y) move--;
        }

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * move);

        if(transform.position.y > maxMove) transform.position = new Vector3(transform.position.x, maxMove, transform.position.z);
        else if(transform.position.y < -maxMove) transform.position = new Vector3(transform.position.x, -maxMove, transform.position.z);
    }
}
