using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource attackSound_dynamic;
    public AudioSource attackSound_peaceful;

    private CheckpointItem curCheckpointItem;

    [System.Serializable]
    public class CheckpointItem
    {
        public bool isDynamicMusic;
        public Checkpoint point;

        public Vector3 GetPosition(){
            return point.GetPosition();
        }
        public bool IsDynamicMusic(){
            return isDynamicMusic;
        }

    }

    [SerializeField]
    public List<CheckpointItem> checkpoints; 

    public void RestartLevel(){

        PlayerPrefs.SetInt("checkpoint", GetLastActiveCheckpoint());

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public CheckpointItem GetCheckpoint(){
        int index = PlayerPrefs.GetInt("checkpoint");
        int index2 = GetLastActiveCheckpoint();

        index = Mathf.Max(index, index2);

        checkpoints[index].point.ActivateCheckpoint();
        return checkpoints[index];
    }

    public int GetLastActiveCheckpoint(){
        for(int i = checkpoints.Count - 1; i >= 0; i --){
            if( checkpoints[i].point.IsActivated() ){
                return i;
            }
        }

        return 0;
    }

    void PlayBackgroundSound(){
        if( curCheckpointItem.IsDynamicMusic() ){
            attackSound_dynamic.Play();
            attackSound_peaceful.Stop();
        }
        else{
            attackSound_peaceful.Play();
            attackSound_dynamic.Stop();
        }
    }

    void Start()
    {
        // if ( PlayerPrefs.HasKey("checkpoint") == false)
            PlayerPrefs.SetInt("checkpoint", 0);

        curCheckpointItem = GetCheckpoint();
        PlayBackgroundSound();
    }

    void Update()
    {
        if( curCheckpointItem != GetCheckpoint() ){
            curCheckpointItem = GetCheckpoint();
            PlayBackgroundSound();
        }
    }
}
