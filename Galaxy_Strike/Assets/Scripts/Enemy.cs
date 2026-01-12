using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 6;
    [SerializeField] int scoreValue = 10;

    Scoreboard _scoreboard;

    private void Start()
    {
        _scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            Debug.Log("HIT");
            _scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}