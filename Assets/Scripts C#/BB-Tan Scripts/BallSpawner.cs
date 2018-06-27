using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{

    public GameObject BallPrefab;

    public int ballAmount = 1;
    public int shootingAmount;

    public Vector3 fingerPos;
    public Vector3 direction;

    public bool isMoving;
    public GameObject arrow;

    public int ballCount = 1;

    float waitTime = 0.1f;

    void Start()
    {
        this.BallPrefab.GetComponent<Renderer>().sharedMaterial.color = GameController.control.PlayerData.BBtanBallColor;
    }

    // Update is called once per frame
    void Update()
    {

        if (ballCount <= 0)
        {
            return;
        }
       if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !isMoving)
            {
                fingerPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
                arrow.gameObject.SetActive(true);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && !isMoving)
            {
                direction.x = fingerPos.x - Input.GetTouch(0).position.x;
                direction.y = fingerPos.y - Input.GetTouch(0).position.y;

                var rotation = Mathf.Atan2(direction.y, direction.x) - Mathf.PI;
                rotation *= Mathf.Rad2Deg;
                rotation += 90;

                arrow.transform.position = gameObject.transform.position;
                arrow.transform.eulerAngles = new Vector3(0, 0, rotation);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended && !isMoving)
            {
                isMoving = true;
                StartCoroutine(timerToShoot());
                arrow.gameObject.SetActive(false);
            }
        }
       
    }

    public void ShootBall()
    {
        var ball = Instantiate(BallPrefab, gameObject.transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(direction.normalized * 1000);
    }

    IEnumerator timerToShoot()
    {
       for(int i = 1; i <= ballAmount; i++)
        {
            yield return new WaitForSeconds(waitTime);
            ShootBall();
        }
    }
}
