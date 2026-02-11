using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOver;
    public GameObject TextScore;
    public GameObject TextTime;
    public GameObject GameTitle;
    
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch(GMState)
        {
        case GameManagerState.Opening:

            GameOver.SetActive(false);

            GameTitle.SetActive(true);

            playButton.SetActive(true);

            break;

        case GameManagerState.Gameplay:

            TextScore.GetComponent<GameScore>().Score = 0;
                
            playButton.SetActive(false);

            GameTitle.SetActive(false);

            playerShip.GetComponent<PlayerControl>().Init();

            enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

            TextTime.GetComponent<TimeCounter>().StartTimeCounter();

            break;

        case GameManagerState.GameOver:

            TextTime.GetComponent<TimeCounter>().StopTimeCounter();

            enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

            GameOver.SetActive(true);

            Invoke("ChangeToOpeningState", 4f);
            break;

        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
