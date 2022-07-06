using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{

    private bool _groundedPlayer;
    public float currentrunningspeed;
    private float _playerSpeed = 100f;
    private PlayerInput _playerinput;
    private InputPlayerActions _Playeractions;
    Animator anim;
    Rigidbody rb;
    [SerializeField] private ShootController _shootcont;
    public static CharacterMove Current;
    public GameObject restext;
    public GameObject loadtext;
    public GameObject WinText;
    //public GameObject loadtext;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _Playeractions = new InputPlayerActions();


    }
    private void OnEnable()
    {
        _Playeractions.Enable();
    }
    private void OnDisable()
    {
        _Playeractions.Disable();
    }
    private void Start()
    {
        Current = this;
        _playerinput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
       
        Time.timeScale = 0f;

    }

    void FixedUpdate()
    {
        if (LevelController.Current == null || !LevelController.Current.gameactive)
        {
            return;
        }
        Move();
        DeadCalculated();
        
    }
    void Move()
    {
        Vector2 input = _Playeractions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0f, input.y);
        rb.velocity = new Vector3(move.x * Time.fixedDeltaTime * _playerSpeed, 0, move.z * Time.fixedDeltaTime * _playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            anim.SetBool("Movement", true);
        }
        else
        {
            anim.SetBool("Movement", false);
        }
    }
    public void ChangeSpeed(float value)
    {
        _playerSpeed = value;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            var direction = other.transform.position - transform.position;
            direction.y = 4f;
            direction = direction.normalized;
            _shootcont.Shoot(direction, transform.position);
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            restext.SetActive(true);
            Dead();
        }
    }
    public void Dead()
    {
        Time.timeScale = 0;
    }
    public void DeadCalculated()
    {
        if (TextMeshUI.txtmsh.ZombieEnemyCount==0)
        {
            loadtext.SetActive(true);
            if (LevelController.Current.currentlevel==5)
            {
                WinText.SetActive(true); 
            }
            Time.timeScale=0f;

        }
    }


}


