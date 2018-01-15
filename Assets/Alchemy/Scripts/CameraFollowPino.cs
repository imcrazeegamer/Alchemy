using UnityEngine;
using System.Collections;

public class CameraFollowPino : MonoBehaviour {

    Transform player;

    float offsetX,offsetY;
    static bool cameraExists;
    // Use this for initialization
    void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
            Destroy(gameObject);
        
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        if (player_go == null)
        {
            Debug.LogError("Couldn't find an object with tag 'Player'!");
            return;
        }

        player = player_go.transform;

        offsetX = transform.position.x - player.position.x;
        offsetY = transform.position.y - player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            pos.y = player.position.y + offsetY;
            transform.position = pos;
        }
    }
}
