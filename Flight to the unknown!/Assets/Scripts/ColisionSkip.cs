using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionSkip : MonoBehaviour
{
    Collision Collision;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheatCodeColision();
    }
        void CheatCodeColision()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(GetComponent<BoxCollider>().enabled == false)
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            } 
        }
    }


}
