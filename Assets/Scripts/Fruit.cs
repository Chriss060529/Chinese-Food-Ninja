using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody2D fruitRigidbody; 
    private Collider2D fruitCollider; 
    private ParticleSystem juiceEffect;

    public int points = 1;

    private void Awake()
    {

        fruitRigidbody = GetComponent<Rigidbody2D>(); 
 
        fruitCollider = GetComponent<Collider2D>(); 
        juiceEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {

        GameManager.Instance.IncreaseScore(points);

        if (fruitCollider != null) fruitCollider.enabled = false;
        
        if (whole != null) whole.SetActive(false);

        if (juiceEffect != null) juiceEffect.Play();

        Destroy(gameObject, 1f); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}