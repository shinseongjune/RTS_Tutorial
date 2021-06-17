using UnityEngine;
using RTS;
using UnityEngine.SceneManagement;

/**
 * Singleton that handles loading level details. This includes making sure
 * that all world objects have an objectId set.
 */

public class LevelLoader : MonoBehaviour
{

    private static int nextObjectId = 0;
    private static bool created = false;
    private bool initialised = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(transform.gameObject);
            created = true;
            initialised = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (initialised)
        {
            WorldObject[] worldObjects = GameObject.FindObjectsOfType(typeof(WorldObject)) as WorldObject[];
            foreach (WorldObject worldObject in worldObjects)
            {
                worldObject.ObjectId = nextObjectId++;
                if (nextObjectId >= int.MaxValue) nextObjectId = 0;
            }
        }
    }

    public int GetNewObjectId()
    {
        nextObjectId++;
        if (nextObjectId >= int.MaxValue) nextObjectId = 0;
        return nextObjectId;
    }
}