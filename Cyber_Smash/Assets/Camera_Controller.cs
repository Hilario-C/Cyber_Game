using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public Transform player;
    public float camera_Height_Adj;
    public float ahead_Distance;
    public float Camera_Speed;
    private float look_Ahead;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + look_Ahead, player.position.y + camera_Height_Adj , transform.position.z);
        look_Ahead = Mathf.Lerp(look_Ahead, (ahead_Distance * player.localScale.x), Camera_Speed);
    
    }

}
