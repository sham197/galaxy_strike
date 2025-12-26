using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("HIT");
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}