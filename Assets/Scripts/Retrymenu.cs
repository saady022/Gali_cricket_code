using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retrymenu : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void exitToMain()
    {
        SceneManager.LoadSceneAsync(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
