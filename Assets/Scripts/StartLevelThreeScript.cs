using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelThreeScript : MonoBehaviour
{
    public GameObject Enemy_1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Enemy_1, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
