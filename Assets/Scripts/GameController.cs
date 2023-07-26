using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private Circle _circle;
    [SerializeField] private Camera _camera;
    [SerializeField] private Square _square;
    [SerializeField] private float _squareSpawnDelay;
    [SerializeField] private Target _target;
    [SerializeField] private float _targetSpawnDelay;

    private float _offset;
    private Vector3 _spawnPosition;
    private Vector3 _screenPointTopRight;
    private Vector3 _screenPointDownRight;

    void Start()
    {
        Time.timeScale = 0;
        _offset = _camera.transform.position.x - _circle.transform.position.x;

        _circle.Death += ReloadScene;

        InvokeRepeating(nameof(SpawnSquare), 0.2f, _squareSpawnDelay);
        InvokeRepeating(nameof(SpawnTarget), 1, _targetSpawnDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
        
        MoveCamera();
        CheckCirclePosition();
    }

    private void MoveCamera()
    {
        _camera.transform.position = new Vector3(_circle.transform.position.x + _offset, _camera.transform.position.y,
            _camera.transform.position.z);
    }

    private void SpawnSquare()
    {
        Instantiate(_square, GetSpawnPosition(), Quaternion.identity);
    }

    private void SpawnTarget()
    {
        Instantiate(_target, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector2 GetSpawnPosition()
    {
        GetScreenPoints();
        
        var xSpawnPoint = _screenPointTopRight.x;
        var ySpawnPoint = Random.Range(_screenPointDownRight.y + 1, _screenPointTopRight.y - 1);

        _spawnPosition = new Vector3(xSpawnPoint, ySpawnPoint);

        return _spawnPosition;
    }

    private void CheckCirclePosition()
    {
        GetScreenPoints();
        
        if (_circle.transform.position.y < _screenPointDownRight.y || _circle.transform.position.y > _screenPointTopRight.y-1)
        {
            ReloadScene();
        }
    }

    private void GetScreenPoints()
    {
        _screenPointTopRight =
                    _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _screenPointDownRight =
                    _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0));
    }

    private void OnDisable()
    {
        _circle.Death -= ReloadScene;
    }
}
