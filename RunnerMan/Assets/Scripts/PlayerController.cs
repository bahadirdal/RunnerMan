using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 8;
    float XSpeed;
    float maxXPosition = 4.5f;
    bool isPlayerMoving;
    Animator humanAC;
    public GameObject gameOverPanel;
    public GameObject successPanel;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerMoving = true;
        humanAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerMoving == false)
        {
            return;
        }

        float touchX = 0;
        float newXValue = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            XSpeed = 250f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            XSpeed = 500f;
            touchX = Input.GetAxis("Mouse X");
        }

        newXValue = transform.position.x + XSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXPosition, maxXPosition);

        Vector3 playerNewPosition = new Vector3(newXValue, 0, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isPlayerMoving = false;
            ShowSuccessPanel();
        }
        if (other.tag == "Enemy")
        {
            isPlayerMoving = false;
            StartDeathAnimation();
            ShowGameOverPanel();
        }
    }

    private void StartDeathAnimation()
    {
        humanAC.SetBool("isHumanDead", true);
    }

    public void NextLevelButtonTapped()
    {
        LevelLoader.instance.NextLevel();
    }
    public void RestartButtonTapped()
    {
        LevelLoader.instance.GetLevel();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowSuccessPanel()
    {
        successPanel.SetActive(true);
    }
}
