using UnityEngine;

public class ExitSpawner : MonoBehaviour
{
    public static ExitSpawner Instance;

    [Header("Spawning")]
    public GameObject levelExitPrefab;    
    public Transform spawnPoint;        
    public int killsNeeded = 5;          

    private int currentKills = 0;
    private bool exitSpawned = false;

    private void Awake()
    {
        // Simple singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterKill()
    {
        if (exitSpawned) return;

        currentKills++;

        if (currentKills >= killsNeeded)
        {
            SpawnExit();
        }
    }

    private void SpawnExit()
    {
        if (levelExitPrefab == null || spawnPoint == null)
        {
            Debug.LogError("ExitSpawner is missing prefab or spawnPoint!");
            return;
        }

        Instantiate(levelExitPrefab, spawnPoint.position, Quaternion.identity);
        exitSpawned = true;
        Debug.Log("Level Exit Spawned!");
    }
}
