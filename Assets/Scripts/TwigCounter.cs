using UnityEngine;
using TMPro;

public class TwigCounter : MonoBehaviour
{
    public static TwigCounter Instance { get; private set; }

    [Header("UI")]
    public TMP_Text twigText;

    [Header("Twig Settings")]
    public GameObject twigPrefab;     // assign your twig prefab here
    public int twigCountToSpawn = 30; // how many to spawn at start
    public Vector2 spawnArea = new Vector2(20f, 20f); // map area to fill
    public float spawnHeight = 0.01f; // height above ground
    public GameObject endScreen;
    
    float timer;
    public TMP_Text timer_label;

    
    private int twigBrokenCount = 0;

    void Awake()
    {
        // singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        timer = 0f;
        SpawnTwigs();
        UpdateText();
    }

    void Update() {
        if (timer > 30) {
            twigCountToSpawn = 30;
            endScreen.SetActive(true);
            endScreen.GetComponentInChildren<TMP_Text>().text = "You Lose!";
            Time.timeScale = 0;
        }
        else if (timer < 30 && twigBrokenCount == 30) {
            endScreen.SetActive(true);
            endScreen.GetComponentInChildren<TMP_Text>().text = "You Win!";
            Time.timeScale = 0;
        }
        timer = Time.timeSinceLevelLoad;
        timer_label.text = $"Timer: {Mathf.Round(30-timer).ToString()}";
    }

    public void AddTwig()
    {
        twigBrokenCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        twigText.text = $"Twigs: {twigBrokenCount}";
    }

    private void SpawnTwigs()
    {
        for (int i = 0; i < twigCountToSpawn; i++)
        {
            float x = Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f);
            float z = Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f);
            Vector3 position = new Vector3(x, spawnHeight, z);

            Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            Instantiate(twigPrefab, position, rotation);
        }
    }
}