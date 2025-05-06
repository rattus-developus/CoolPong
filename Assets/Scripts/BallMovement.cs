using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed;
    float moveSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float xBound;
    Vector2 direction;

    public bool isGoingRight()
    {
        return direction.x > 0f;
    }

    void Start()
    {
        StartCoroutine(Reset());
    }

    void Update()
    {
        moveSpeed += Time.deltaTime * acceleration;
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        if(transform.position.x > xBound)
        {
            GameManager.Instance.Score1();
            StartCoroutine(Reset());
        }
        if(transform.position.x < -xBound)
        {
            GameManager.Instance.Score2();
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {

        direction = Vector2.zero;
        transform.position = Vector2.zero;
        yield return new WaitForSeconds(1.5f);
        moveSpeed = baseSpeed;
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            direction *= new Vector2(1, -1);
        }
        else if(collision.gameObject.CompareTag("Player")) direction = (transform.position - collision.transform.position).normalized;
    }
}
