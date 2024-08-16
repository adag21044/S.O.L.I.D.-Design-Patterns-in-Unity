using UnityEngine;

// Bad example of Dependency Inversion Principle
public class Mover_Bad : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        movement = movement * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
