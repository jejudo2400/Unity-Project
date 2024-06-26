using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameOver;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() {
        isGameOver = true;

        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
