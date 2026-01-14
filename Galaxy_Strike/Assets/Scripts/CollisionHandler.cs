using UnityEngine;
using UnityEngine.UIElements;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;
    
    private GameSceneManager _gameSceneManager;
    
    private void Start()
    {
        _gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        _gameSceneManager.ReloadLevel();
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log($"Hit {other.gameObject.name}");
    }
}