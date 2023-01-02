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
        // Store the input value of the left-right direction buttons
        float hlInput = Input.GetAxis("Horizontal");

        // Calculate and store the max limits for the player to move
        float rightLimit = rightCorner - halfWidthOfPlayer;
        float leftLimit = leftCorner + halfWidthOfPlayer;

        // Store the player's current position
        Vector2 currentPos = transform.position;

        // If the player pressed right direction AND they're to the left side of the right limit, keep moving
        if (hlInput > 0f && transform.position.x < rightLimit)
        {
            // Calculate the player's new position
            Vector2 newPos = currentPos + new Vector2(1f, 0f);

            // Move the player towards the new position using the given speed
            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
        // If the player pressed left direction AND they're to the right side of the left limit, keep moving
        else if (hlInput < 0f && transform.position.x > leftLimit)
        {
            // Same as above but new position is the opposite direction
            Vector2 newPos = currentPos - new Vector2(1f, 0f);
            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
