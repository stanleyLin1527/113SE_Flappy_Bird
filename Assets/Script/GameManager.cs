using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private bool isMute = false;
    private Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject pauseText;
    [SerializeField] GameObject gameoverImage;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject muteButton;
    [SerializeField] Sprite[] volumeSprites;
    private AudioSource bgm;

    private void Awake() {
        Application.targetFrameRate = 999;

        player = FindObjectOfType<Player>();
        bgm = GetComponent<AudioSource>();

        Stop();
    }

    public void Play() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();

        scoreText.gameObject.SetActive(true);
        pauseButton.SetActive(true);

        playButton.SetActive(false);
        gameoverImage.SetActive(false);
        titleText.SetActive(false);
        resumeButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        // Destory previous game's objects
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes) {
            Destroy(pipe.gameObject);
        }
    }

    // For gameover pause
    public void Stop() {
        Time.timeScale = 0f;
        player.enabled = false;

        pauseButton.SetActive(false);
    }

    // For in-game pause
    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;

        resumeButton.SetActive(true);
        pauseText.SetActive(true);
    }

    // For in-game pause
    public void Resume() {
        Time.timeScale = 1f;
        player.enabled = true;

        resumeButton.SetActive(false);
        pauseText.SetActive(false);
    }

    public void Mute() {
        isMute = !isMute;
        bgm.mute = isMute;
        muteButton.GetComponent<Image>().sprite = volumeSprites[isMute ? 1: 0];
    }

    public void GameOver() {
        gameoverImage.SetActive(true);
        playButton.SetActive(true);

        Stop();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
