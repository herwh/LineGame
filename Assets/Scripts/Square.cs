using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _amplitude;

    private float _y;
    private float _randomValue;

    private void Start()
    {
        _randomValue = Random.value;
        _y = transform.position.y;
    }

    private void Update()
    {
        MoveLoop();
    }

    private void MoveLoop()
    {
        transform.position =
            new Vector3(transform.position.x, _y + Mathf.Sin((Time.time +_randomValue)* _speed)*_amplitude, transform.position.z);
    }
    
}
