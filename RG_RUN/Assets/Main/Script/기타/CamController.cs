using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera cam;
    Player player;

    public GameObject bg1, bg2;

    private void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        StartCoroutine(cor());
    }

    private void Update()
    {
        cam.transform.position = new Vector3
            (player.transform.position.x,
            Mathf.Clamp(player.transform.position.y - 3, 1, 10),
            cam.transform.position.z);
    }
    IEnumerator cor()
    {
        int i = 1;
        while (true)
        {
            if(player.transform.position.x > 152.8 * i)
            {
                i++;
                if(i % 2 == 0) bg1.transform.position = new Vector3(152.8f * i, -4.14f, 0);
                else bg2.transform.position = new Vector3(152.8f * i, -4.14f, 0);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
