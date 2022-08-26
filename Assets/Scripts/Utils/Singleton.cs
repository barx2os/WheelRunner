using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
