using UnityEngine;
using UnityEngine.EventSystems; // for blocking UI taps

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public bool gameStarted = false;
    public PipeSpawnScript spawner;
    public CloudSpawnScript cloudSpawner;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdIsAlive = false;
        myRigidbody.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (Tapped())
        {
            if (!gameStarted)
            {
                startGame();
            }

            if (birdIsAlive)
            {
                myRigidbody.linearVelocity = Vector2.up * flapStrength;
            }
        }
    }

    bool Tapped()
    {
        // Block UI touches
        if (EventSystem.current != null)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return false;

            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return false;
        }

        // Space
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        // Mouse click
        if (Input.GetMouseButtonDown(0))
            return true;

        // Touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameStarted) return;

        logic.gameOver();
        birdIsAlive = false;
    }

    public void startGame()
    {
        gameStarted = true;
        birdIsAlive = true;
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;

        if (spawner != null)
            spawner.gameStarted = true;

        if (cloudSpawner != null)
            cloudSpawner.StartSpawning();
    }
}
