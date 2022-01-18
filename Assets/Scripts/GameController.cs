using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    // we can get this instance from other scripts vry easily but it can be destroyed when we have transition b/w scens.
    public static GameController Instance { get; private set; }

    [SerializeField]
    private int knifeCount;

    [Header("kinfe spawning")]
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private GameObject knifeObject;
    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
    }
    private void Start()
    {
        GameUI.SetInitialDisplayCount(knifeCount);
        SpawnKnife();
    }

    public void OnSuccessfullKnifeHit()
    {
        // when we havw no knife remaining
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            // Player won
            StartGameOverSequence(true);
        }
    }
    private void SpawnKnife()
    {
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);

    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCorutine", win);
    }
    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            RestartGame();
        }
        else
        {
            GameUI.ShowRestartBotton();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
