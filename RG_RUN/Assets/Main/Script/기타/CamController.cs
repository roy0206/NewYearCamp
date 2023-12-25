using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera cam;
    Player player;

    private void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        cam.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, 1, 10), cam.transform.position.z);
    }
}
