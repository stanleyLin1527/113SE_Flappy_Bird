using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMananger : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject pauseText;
    [SerializeField] GameObject gameoverImage;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject muteButton;
    [SerializeField] Sprite[] volumeSprites;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Play()
    {

        scoreText.gameObject.SetActive(true);
        pauseButton.SetActive(true);

        playButton.SetActive(false);
        gameoverImage.SetActive(false);
        titleText.SetActive(false);
        resumeButton.SetActive(false);
    }

    // For gameover pause
    public void Stop()
    {
        pauseButton.SetActive(false);
    }

    // For in-game pause
    public void Pause()
    {
        resumeButton.SetActive(true);
        pauseText.SetActive(true);
    }

    // For in-game pause
    public void Resume()
    {
        resumeButton.SetActive(false);
        pauseText.SetActive(false);
    }

    public void ToggleMute(bool isMute)
    {
        muteButton.GetComponent<Image>().sprite = volumeSprites[isMute ? 1 : 0];
    }

    public void GameOver()
    {
        gameoverImage.SetActive(true);
        playButton.SetActive(true);

        Stop();
    }
}
