using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainLevel : MonoBehaviour 
{
	public bool levelLoaded = false;
	public int scenenumber;

	public GestureListener gesture;

    private void Awake()
    {
        gesture = FindFirstObjectByType<GestureListener>();
    }

    void Update() 
	{
		KinectManager manager = KinectManager.Instance;

        if (!levelLoaded && manager && KinectManager.IsKinectInitialized())
		{
            //if (gesture.IsRiseRightHand())
            {
                levelLoaded = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
