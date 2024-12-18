using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private Player player;

    [SerializeField] private UIMananger UIMananger_;
    [SerializeField] private AudioMananger AudioMananger_;

    private void Awake() {
        Application.targetFrameRate = 999;

        player = FindObjectOfType<Player>();

        Stop();
    }

    public void Play() {
        score = 0;

        UIMananger_.Play();
        UIMananger_.UpdateScore(score);

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

        UIMananger_.Stop();
    }

    // For in-game pause
    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;

        UIMananger_.Pause();
    }

    // For in-game pause
    public void Resume() {
        Time.timeScale = 1f;
        player.enabled = true;

        UIMananger_.Resume();
    }

    public void ToggleMute() {

        AudioMananger_.ToggleMute();
        UIMananger_.ToggleMute(AudioMananger_.getIsMute());
    }

    public void GameOver() {
        UIMananger_.GameOver();

        Stop();
    }

    public void IncreaseScore() {
        score++;

        UIMananger_.UpdateScore(score);
    }
}
