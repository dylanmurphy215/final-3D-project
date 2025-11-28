using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float rotationSpeed = 0f;

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            moveX = -1f;
        if (Input.GetKey(KeyCode.DownArrow))
            moveX = 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveZ = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveZ = 1f;

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

