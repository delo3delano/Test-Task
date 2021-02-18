using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject button_restart;
    
    void Start()
    {
        button_restart.SetActive(false);
    }

    public void OnTriggerEnter(Collider cubes)
    {
        if(cubes.tag == "destroyobj")
        {
            Destroy(gameObject);
            button_restart.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
