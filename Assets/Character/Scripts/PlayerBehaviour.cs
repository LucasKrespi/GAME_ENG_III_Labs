using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private Rigidbody2D player_Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        player_Rigidbody2D.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }
}
