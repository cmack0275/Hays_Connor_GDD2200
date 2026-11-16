using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //Contains the prefab of the ball that will spawn in random locations.
    public GameObject ballPrefab;
    
    //A ball will spawn at least 5 units away from the spawn point either on the left or right sides.
    public float xLimit = 5f;
    //A ball will spawn at most 2 units away from the spawn point either above or below it.
    public float yLimit = 2f;
    //A ball will at most 5 units either behind or in front of the spawn point.
    public float zLimit = 5f;
    
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
        //A ball will spawn in between in -5 and 5 units in the x direction from the spawn point. 
        float ranX = Random.Range(-xLimit, xLimit);
        //A ball will spawn in between in -2 and 2 units in the y direction from the spawn point. 
        float ranY = Random.Range(-yLimit, yLimit);
        //A ball will spawn in between in -5 and 5 units in the z direction from the spawn point. 
        float ranZ = Random.Range(-zLimit, zLimit);
        
        //Stores the random X, Y, & Z positions in a 3D vector (vector3).
        Vector3 ranOffset = new Vector3(ranX, ranY, ranZ);
        //Stores the position of the ball's spawn point.
        Vector3 spawnPointPosition = transform.position;
        //Converts the position of the spawner and the offset over to a random position adjacent to the spawn point. 
        Vector3 spawnPosition = spawnPointPosition + ranOffset;
        
        //Spawns a ball on the spawn position with it randomly rotated.
        Instantiate(ballPrefab, spawnPosition, Random.rotation);
    }
}

