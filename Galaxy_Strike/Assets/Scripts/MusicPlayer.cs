using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        var numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        
        if (numOfMusicPlayers > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
