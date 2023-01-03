using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer player;
    public float moveSpeed = 2f;

    private Camera mainCamera;
    private float rightCorner;
    private float leftCorner;
    private float halfWidthOfPlayer;

    void Start()
    {
        mainCamera = Camera.main;
        rightCorner = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        leftCorner = mainCamera.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
        halfWidthOfPlayer = player.bounds.size.x * 0.5f;
    }

    void Update()
    {
        float hlInput = Input.GetAxis("Horizontal");

        float rightLimit = rightCorner - halfWidthOfPlayer;
        float leftLimit = leftCorner + halfWidthOfPlayer;

        Vector2 currentPos = transform.position;

        if (hlInput > 0f && transform.position.x < rightLimit)
        {
            Vector2 newPos = currentPos + new Vector2(1f, 0f);

            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
        else if (hlInput < 0f && transform.position.x > leftLimit)
        {
            Vector2 newPos = currentPos - new Vector2(1f, 0f);
            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
