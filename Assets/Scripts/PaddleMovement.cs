using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float maxMove;
    [SerializeField] bool isPlayer1;

    void Update()
    {
        int move = 0;

        if(Input.GetKey(KeyCode.W) && isPlayer1) move++;
        if(Input.GetKey(KeyCode.S) && isPlayer1) move--;

        if(Input.GetKey(KeyCode.UpArrow) && !isPlayer1) move++;
        if(Input.GetKey(KeyCode.DownArrow) && !isPlayer1) move--;

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * move);

        if(transform.position.y > maxMove) transform.position = new Vector3(transform.position.x, maxMove, transform.position.z);
        else if(transform.position.y < -maxMove) transform.position = new Vector3(transform.position.x, -maxMove, transform.position.z);
    }
}
