using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int iLevelToLoad;
    public int sLevelToLoad;

    public bool useIntegerToLoadLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Boss1 boss1){
        if(boss1.health < 0){
            LoadScene();
        }
    }

    void LoadScene(){
        if(useIntegerToLoadLevel){
            SceneManager.loadScene(iLevelToLoad);
        } else{
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
