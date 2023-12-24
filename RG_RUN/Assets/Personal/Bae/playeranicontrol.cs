using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranicontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tr;
    public Transform player_colision;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = player_colision.position;
        tr.position = new Vector3(tr.position.x, tr.position.y, tr.position.z-1);
    }
}
