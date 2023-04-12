using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // references "player" GameObject's postition.
    // Are all attributes of all GameObjects public to all scripts?
    // (as long as not parts of scripts defined privately?)
    // NEVERMIND: this player declaration exposes it to Unity Inspector where object is chosen
    public GameObject player;   

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // offset is constant and only need to be calculated once, Start() is the right spot
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    // "can't control order of updates?" Is this just meaning gameplay unpredicatility or 
    // Unity literally is not set up to control Update() order of different scripts?
    //      vs execution order

    // Anyways, LateUpdate() runs after all Update(). Good place for camera, last known position, etc.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
