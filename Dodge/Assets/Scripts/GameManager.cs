using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  // 게임오버 시 활성화할 텍스트 게임 오브젝트;
    public Text timeText;  //생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;  // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameOver;

    void Start() {
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(!isGameOver){
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int) surviveTime;
        } else{
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame(){
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime){
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int) bestTime;
    }
}
