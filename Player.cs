using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Rigidbody _rig;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private CapsuleCollider _Caps; 
    private Vector3 Direction; 
    public bool Departure;
    public bool Shock = false;
    public bool Win = false; 
    public float FallingTimer;
    private RaycastHit hit;
    #endregion

    public static Player Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(Instance); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _rig = gameObject.GetComponent<Rigidbody>();
        _Caps = gameObject.GetComponent<CapsuleCollider>();
        Shock = false;
    }

    // Update is called once per frame
    void Update()
    {
        Started();
         
    }
    private void  Started()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
            }
            Departure = true; 
        }
        Run(); 
    }
    private void Run()
    {
        if (Departure && !Shock && !Win)
        {
            _anim.SetTrigger("Start");
            Direction = new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            _rig.position += Direction; 
        }
        if(_rig.velocity.y < -7)
        {
            Shock = true;
            _anim.SetBool("Fallen", true);
            Direction = new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            _rig.position += Direction;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cube") || collision.collider.CompareTag("Trap"))
        {
            if (collision.GetContact(0).point.y >= transform.position.y+0.3)
            {
                Debug.Log(collision.GetContact(0).point.y);
                Debug.Log(transform.position.y);
                Shock = true;
                _anim.SetBool("Fallen", true);
                Vector3 CollisionDir = new Vector3(-MoveSpeed * 2, 0f, -MoveSpeed * (3 / 2));
                _rig.AddForce(CollisionDir, ForceMode.Impulse);
            }
        }
    }
    public void WinGame()
    {
        if (!Shock)
        {
            Win = true;
            MoveSpeed = 0;
            _anim.SetBool("Win", true);
        }
    }
}
