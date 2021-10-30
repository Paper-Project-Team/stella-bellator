using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelOneScript : MonoBehaviour
{
    public Transform Enemy_1;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Transform Enemy1 = Instantiate(Enemy_1, new Vector3(43.58f, -2.93f, 0f), Quaternion.identity);
        Transform Enemy2 = Instantiate(Enemy_1, new Vector3(172.6f, -3.03f, 0f), Quaternion.identity);
        Transform Enemy3 = Instantiate(Enemy_1, new Vector3(270.33f, -2.94f, 0f), Quaternion.identity);
        Transform Enemy4 = Instantiate(Enemy_1, new Vector3(355.6f, -2.94f, 0f), Quaternion.identity);
        Transform Enemy5 = Instantiate(Enemy_1, new Vector3(486.51f, -2.75f, 0f), Quaternion.identity);
        Transform Enemy6 = Instantiate(Enemy_1, new Vector3(529.61f, -2.94f, 0f), Quaternion.identity);
        Enemy1.transform.localScale = new Vector3(13.5f, 13.5f, 1f);
        Enemy2.transform.localScale = new Vector3(13.5f, 13.5f, 1f);
        Enemy3.transform.localScale = new Vector3(13.5f, 13.5f, 1f);
        Enemy4.transform.localScale = new Vector3(13.5f, 13.5f, 1f);
        Enemy5.transform.localScale = new Vector3(13.5f, 13.5f, 1f);
        Enemy6.transform.localScale = new Vector3(13.5f, 13.5f, 1f);

        EnemyScript EnemyOneScript = Enemy1.GetComponent<EnemyScript>();
        EnemyOneScript.Target = Player;

        EnemyScript EnemyTwoScript = Enemy2.GetComponent<EnemyScript>();
        EnemyTwoScript.Target = Player;

        EnemyScript EnemyThreeScript = Enemy3.GetComponent<EnemyScript>();
        EnemyThreeScript.Target = Player;

        EnemyScript EnemyFourScript = Enemy4.GetComponent<EnemyScript>();
        EnemyFourScript.Target = Player;

        EnemyScript EnemyFiveScript = Enemy5.GetComponent<EnemyScript>();
        EnemyFiveScript.Target = Player;

        EnemyScript EnemySixScript = Enemy6.GetComponent<EnemyScript>();
        EnemySixScript.Target = Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
