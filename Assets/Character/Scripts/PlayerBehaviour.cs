using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private Rigidbody2D player_Rigidbody2D;
    private GameObject pauseMenu;
    
    void Start()
    {
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
        pauseMenu = GameObject.Find("PauseCanvas");
        pauseMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        player_Rigidbody2D.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
