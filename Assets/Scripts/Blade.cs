<<<<<<< HEAD
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private Camera mainCamera;

    private Collider2D sliceCollider; 
    private TrailRenderer sliceTrail;

    public Vector3 direction { get; private set; }
    public bool slicing { get; private set; }

    private void Awake()
    {
        mainCamera = Camera.main;

        sliceCollider = GetComponent<Collider2D>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartSlice();
        } else if (Input.GetMouseButtonUp(0)) {
            StopSlice();
        } else if (slicing) {
            ContinueSlice();
        }
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f; 
        transform.position = position;

        slicing = true;
        
        if (sliceCollider != null) sliceCollider.enabled = true;
        if (sliceTrail != null) {
            sliceTrail.enabled = true;
            sliceTrail.Clear();
        }
    }

    private void StopSlice()
    {
        slicing = false;
        if (sliceCollider != null) sliceCollider.enabled = false;
        if (sliceTrail != null) sliceTrail.enabled = false;
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f; 
        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        
        if (sliceCollider != null) {
            sliceCollider.enabled = velocity > minSliceVelocity;
        }

        transform.position = newPosition;
    }
=======
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private Camera mainCamera;

    private Collider2D sliceCollider; 
    private TrailRenderer sliceTrail;

    public Vector3 direction { get; private set; }
    public bool slicing { get; private set; }

    private void Awake()
    {
        mainCamera = Camera.main;

        sliceCollider = GetComponent<Collider2D>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartSlice();
        } else if (Input.GetMouseButtonUp(0)) {
            StopSlice();
        } else if (slicing) {
            ContinueSlice();
        }
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f; 
        transform.position = position;

        slicing = true;
        
        if (sliceCollider != null) sliceCollider.enabled = true;
        if (sliceTrail != null) {
            sliceTrail.enabled = true;
            sliceTrail.Clear();
        }
    }

    private void StopSlice()
    {
        slicing = false;
        if (sliceCollider != null) sliceCollider.enabled = false;
        if (sliceTrail != null) sliceTrail.enabled = false;
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f; 
        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        
        if (sliceCollider != null) {
            sliceCollider.enabled = velocity > minSliceVelocity;
        }

        transform.position = newPosition;
    }
>>>>>>> eba81fc (Update: Added prefabs and modified game scripts)
}