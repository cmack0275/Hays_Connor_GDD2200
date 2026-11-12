using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //Contains the prefab of the ball that will spawn in random locations.
    public GameObject ballPrefab;
    //A ball will spawn at least 10 units away from the camera.
    public float lowerZLimit = 10f;
    //A ball will spawn at most 15 units away from the camera.
    public float upperZLimit = 15f;

    private void OnEnable()
    {
        //When the ball spawn button is pressed, the event manager enables OnClickBallSpawn and calls the SpawnBall method.
        EventManager.OnClickBallSpawn += SpawnBall;
    }
    
    private void OnDisable()
    {
        //When the ball spawn button is not pressed, the event manager keeps OnClickBallSpawn disabled. This is to prevent
        //potential memory leaks and other unforeseen problems.
        EventManager.OnClickBallSpawn -= SpawnBall;
    }

    private void SpawnBall()
    {
        //A ball will spawn in between 10% and 90% of the camera's width. 
        float ranX = Random.Range(0.1f, 0.9f);
        //A ball will spawn in between 10% and 90% of the camera's height. 
        float ranY = Random.Range(0.1f, 0.9f);
        //A ball will spawn in between the lower and upper Z limits. 
        float ranZ = Random.Range(lowerZLimit, upperZLimit);
        
        //Stores the random X, Y, & Z positions in a 3D vector (vector3).
        Vector3 cameraCoords = new Vector3(ranX, ranY, ranZ);
        //Converts the camera coordinates over to a position within the scene's world and stores it. 
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(cameraCoords);
        
        //Spawns a ball on the spawn position with it randomly rotated.
        Instantiate(ballPrefab, spawnPosition, Random.rotation);
    }
}

