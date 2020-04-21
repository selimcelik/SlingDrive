using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameStarted = false;
    float elapsedTime = 3;
    public Text startText;
    public Transform startPos;
    public GameObject[] roads;


    //okuması daha rahat olur diye böyle yaptım
    public GameObject pattern1;
    public GameObject pattern2;
    public GameObject pattern3;
    public GameObject pattern4;


    private int lastPattern;
    private GameObject lastGO;

    private void Start()
    {
        

        if (Random.value < 0.5f)
        {
            //1 ve 2
            GameObject tempGO = Instantiate(pattern1, Vector3.zero, Quaternion.identity);
            Vector3 tempPos = new Vector3(tempGO.transform.position.x + 5.1f, tempGO.transform.position.y - 3.22f, 0);
            lastGO = Instantiate(pattern2, tempPos, Quaternion.identity);
            lastPattern = 2;


        }
        else
        {
            //4 ve 1
            GameObject tempGO = Instantiate(pattern4, Vector3.zero, Quaternion.identity);
            Vector3 tempPos = new Vector3(tempGO.transform.position.x, tempGO.transform.position.y + 2.44f, 0f);
            lastGO = Instantiate(pattern1, tempPos, Quaternion.identity);
            lastPattern = 1; 
        }


        for (int i = 0; i < 100; i++)
        {
            switch (lastPattern)
            {
                case 1:
                    Vector3 tempPos = new Vector3(lastGO.transform.position.x + 5.1f, lastGO.transform.position.y - 3.22f, 0);
                    lastGO = Instantiate(pattern2, tempPos, Quaternion.identity);
                    lastPattern = 2;
                    break;
                case 2:
                    tempPos = new Vector3(lastGO.transform.position.x - 5.1f, lastGO.transform.position.y + 3.16f, 0);
                    lastGO = Instantiate(pattern3, tempPos, Quaternion.identity);
                    lastPattern = 3;
                    break;
                case 3:
                    if (Random.value < 0.5f)
                    {
                        tempPos = new Vector3(lastGO.transform.position.x, lastGO.transform.position.y + 10.16f, 0);
                        lastGO = Instantiate(pattern1, tempPos, Quaternion.identity);
                        lastPattern = 1;
                    }
                    else
                    {
                        tempPos = new Vector3(lastGO.transform.position.x, lastGO.transform.position.y + 10.3f, 0);
                        lastGO = Instantiate(pattern4, tempPos, Quaternion.identity);
                        lastPattern = 4;
                    }
            break;
                case 4:
                    tempPos = new Vector3(lastGO.transform.position.x, lastGO.transform.position.y + 2.44f, 0f);
                    lastGO = Instantiate(pattern1, tempPos, Quaternion.identity);
                    lastPattern = 1;
                    break;
                default:
                    break;
            }
        }










    }

    private void OnEnable()
    {
        startText.text = "TAP TO START";


    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {
        //elapsedTime -= Time.deltaTime;

        //if (elapsedTime > 0)
        //    return;
        //else
        //{
        //    StartGame();
        //}


        if (Input.GetMouseButton(0))
        {
            startText.enabled = false;
            StartGame();
        }



    }
    private void StartGame()
    {
        isGameStarted = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
