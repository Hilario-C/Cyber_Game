using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            

            collision.GetComponent<Player_Movement>().MoveFaster();
            gameObject.SetActive(false);
            Debug.Log("been grabbed");
        }
    }
}
