using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Touch touch;

    public GameObject _cube;

    public GameObject circle_player;

    float gravity_Speed;


    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        gravity_Speed = -3;
        StartCoroutine(Spawn_OBject_cube());
        StartCoroutine(Time_Speed());
    }
    void FixedUpdate()
    {
        control();
    }

    IEnumerator Spawn_OBject_cube()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            float _rand = Random.Range(-2.2f, 2.2f);
            Instantiate(_cube, new Vector3(_rand,6.5f, 0), Quaternion.identity);
            Physics.gravity = new Vector3(0, gravity_Speed, 0);
        }
    }
    IEnumerator Time_Speed()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            gravity_Speed -= 2;
        }
    }
    public void OnTriggerEnter(Collider cubes)
    {
        if(cubes.tag == "destroyobj")
        {
            Destroy(cubes.gameObject);
        }
    }
    void control()
    {
        float max_Right_Position = -2.3f;
        float max_Left_Position = 2.3f;
    
        if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    float drag_Distance = touch.deltaPosition.x* Time.deltaTime ;
                    

                    if (drag_Distance < 0) 
                    {
                        if(circle_player.transform.localPosition.x != max_Right_Position){
                        circle_player.transform.localPosition += new Vector3(-5f, 0f, 0)* Time.deltaTime;}
                    } 
                    else if (drag_Distance > 0) 
                    {
                        if(circle_player.transform.localPosition.x != max_Left_Position){
                        circle_player.transform.localPosition += new Vector3(5f, 0f, 0)* Time.deltaTime;}
                    }
                
            }
            } else {
                
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if(circle_player.transform.localPosition.x != max_Right_Position){
                    circle_player.transform.localPosition += new Vector3(-5f, 0f, 0)* Time.deltaTime;}
                    
                } 
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    if(circle_player.transform.localPosition.x != max_Left_Position){
                    circle_player.transform.localPosition += new Vector3(5f, 0f, 0)* Time.deltaTime;}
                    
                }
            }
    }
    public void btn_rest()
    {
        SceneManager.LoadScene(0);
    }
}
