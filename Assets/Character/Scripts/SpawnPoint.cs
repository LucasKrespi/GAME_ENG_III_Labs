using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject player_Prefab;

    static PlayerBehaviour player = null;
    // Start is called before the first frame update
    void Start()
    {

        if (player == null)
        {
            GameObject newPlayer = Instantiate(player_Prefab, transform.position, transform.rotation);
            player = newPlayer.GetComponent<PlayerBehaviour>();
        }
    }
}
