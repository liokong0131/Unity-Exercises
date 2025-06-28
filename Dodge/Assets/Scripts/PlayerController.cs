using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start(){
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 설정
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // 리지드바디의 속도에 newVelocity를 할당
        playerRigidbody.linearVelocity = newVelocity;
    }
    
    public void Die(){
        gameObject.SetActive(false);
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.EndGame();
    }

}
