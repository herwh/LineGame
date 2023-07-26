using DefaultNamespace;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _minDistanceToCatch;
    [SerializeField] private float _minDistanceToDestroy;
    [SerializeField] private float _speed;
    void Update()
    {
        MoveToCircle();
    }

    private void MoveToCircle()
    {
        var distanceToCircle = PlayerManager.instance.Player.transform.position-transform.position;
        var direction = distanceToCircle.normalized;
        var magnitude = distanceToCircle.magnitude;
        
        if ( magnitude < _minDistanceToCatch)
        {
            transform.position += direction * (_speed * Time.deltaTime);
            
            if (magnitude <=_minDistanceToDestroy)
            {
                PlayerManager.instance.CatchTarget();
                Destroy(gameObject);
            }
        }
        
    }
}
