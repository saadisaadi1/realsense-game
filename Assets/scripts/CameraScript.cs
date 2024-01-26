using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Bow bow;
    private float camera_move_speed;
    private GameManager game_manager;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("game manager").GetComponent<GameManager>();
        camera_move_speed = bow.bow_move_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_manager.editing && game_manager.in_wave && !bow.using_special_attack)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= camera_move_speed * Vector3.right * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += camera_move_speed * Vector3.right * Time.deltaTime;
            }
        }
    }
}
