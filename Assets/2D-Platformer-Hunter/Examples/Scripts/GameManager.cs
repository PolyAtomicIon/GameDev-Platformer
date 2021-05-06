using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    public List<Checkpoint> checkpoints; 

    public void RestartLevel(){

        PlayerPrefs.SetInt("checkpoint", GetLastActiveCheckpoint());

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public Vector3 GetCheckpoint(){
        int index = PlayerPrefs.GetInt("checkpoint");
        checkpoints[index].ActivateCheckpoint();
        return checkpoints[index].GetPosition();
    }

    public int GetLastActiveCheckpoint(){
        for(int i = checkpoints.Count - 1; i >= 0; i --){
            if( checkpoints[i].IsActivated() ){
                return i;
            }
        }

        return 0;
    }

    void Start()
    {
        if ( PlayerPrefs.HasKey("checkpoint") == false)
            PlayerPrefs.SetInt("checkpoint", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
