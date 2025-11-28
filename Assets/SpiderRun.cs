using UnityEngine;

public class SpiderRun8WayFixed : MonoBehaviour
{
    public GameObject spider1;
    public GameObject spider2;
    public float moveSpeed = 2f;       // movement speed
    public float frameTime = 0.2f;     // time per frame for leg animation

    private bool isSpider1Active = true;
    private float timer = 0f;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Gather input (swapped)
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.RightArrow)) vertical -= 1f;  // swapped
        if (Input.GetKey(KeyCode.LeftArrow)) vertical += 1f;   // swapped
        if (Input.GetKey(KeyCode.UpArrow)) horizontal += 1f;       // swapped
        if (Input.GetKey(KeyCode.DownArrow)) horizontal -= 1f;     // swapped

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Move the spider
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the spider to face movement direction if moving
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            // Animate legs
            timer += Time.deltaTime;
            if (timer >= frameTime)
            {
                isSpider1Active = !isSpider1Active;
                spider1.SetActive(isSpider1Active);
                spider2.SetActive(!isSpider1Active);
                timer = 0f;
            }
        }
        else
        {
            // Reset to first frame when idle
            spider1.SetActive(true);
            spider2.SetActive(false);
            isSpider1Active = true;
            timer = 0f;
        }
    }
}

