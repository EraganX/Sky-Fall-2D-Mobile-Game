using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.5f;
    private Rigidbody2D _rigidBody;

    public static bool canMove = false;
    
    private Animator _animator;
    private SpriteRenderer _render;
    Vector3 _position;

    private void Awake()
    {
        _rigidBody=GetComponent<Rigidbody2D>(); 
        _animator=GetComponent<Animator>();
        _render = GetComponent<SpriteRenderer>();
        _position = transform.position;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && canMove==true)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPosition.x<0)
            {
                _render.flipX = false;
                transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
                _animator.SetBool("IsMove", true);
            }//move left
            else
            {
                _render.flipX = true;
                transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
                _animator.SetBool("IsMove", true);
            }//move right

            _position.x = Mathf.Clamp(transform.position.x,GameManager.leftmostWorldPoint.x,GameManager.rightmostWorldPoint.x);
            
            transform.position = _position;
        }
        else
        {
            _animator.SetBool("IsMove", false);
            _rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Cloud"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
