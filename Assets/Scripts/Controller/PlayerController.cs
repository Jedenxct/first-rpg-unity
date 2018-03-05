using UnityEngine;
using Assets.Scripts.Data;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    public float speed;

    private void Start()
    {
        Initialize();
    }

    // movement
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _rigidBody.velocity = new Vector2(moveX * speed, moveY * speed);

        _animator.SetBool("move_right", _rigidBody.velocity.x > 0 ? true : false);
        _animator.SetBool("move_left", _rigidBody.velocity.x < 0 ? true : false);
        _animator.SetBool("move_up", _rigidBody.velocity.y > 0 ? true : false);
        _animator.SetBool("move_down", _rigidBody.velocity.y < 0 ? true : false);
    }

    private void OnLevelWasLoaded(int level)
    {
        Initialize();

        switch (level)
        {
            case 0:
                _rigidBody.position = SpawnPoint.Pyungmoo;
                break;

            case 1:
                _rigidBody.position = SpawnPoint.House1;
                break;
        }
    }

    private void Initialize()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    } 
}
