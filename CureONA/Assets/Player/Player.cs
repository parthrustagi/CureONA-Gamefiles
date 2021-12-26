using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.UI;
[RequireComponent(typeof(MoveController))]

public class Player : InputController
{
    [System.Serializable]
    public new class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse = true;
    }

    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float SprintSpeed;
    [SerializeField] MouseInput MouseControl;
    public static float NewPlayerHealth = 100f;
    private Slider healthBar;
    private Text LivesText;

    private MoveController m_MoveController;
    public bool Margya = false;
    public int PlayerLives = 3;
    
	public MoveController MoveController {
		get {
			if(m_MoveController == null)
				m_MoveController = GetComponent<MoveController>();
			return m_MoveController;
		}
	}
	
	InputController playerInput;
	Vector2 mouseInput;

	void Start()
	{
		healthBar = GameObject.Find("HealthSlider").GetComponent<Slider>();
		LivesText = GameObject.Find("PlayerLives").GetComponent<Text>();
	}
	
	void Awake(){
		playerInput = GameManager.Instance.InputController;
        DontDestroyOnLoad(playerInput);
		GameManager.Instance.LocalPlayer = this;
        
        if(MouseControl.LockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
	}

    public void PlayerDamage(int damage)
    {
        NewPlayerHealth -= damage;
    }

    void Update()
	{
        print("Player Script");

        if(NewPlayerHealth > 0)
        {
            Move();
            LookAround();
            transform.Find("Weapons").gameObject.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            gameObject.GetComponent<PlayerShoot>().enabled = true;
        }
        else if(NewPlayerHealth < -1)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            transform.Find("Weapons").gameObject.SetActive(false);
            gameObject.GetComponent<PlayerShoot>().enabled = false;

            if (PlayerLives==1)
            {
				GetComponent<PlayerAnimation>().PlayerIsDead();
				NewPlayerHealth = -1;
                Margya = true;
                HitPause();
			}
			else
			{
				PlayerLives--;
				GetComponent<PlayerAnimation>().PlayerStays();
				NewPlayerHealth = 100;
                this.GetComponent<InputController>().enabled = false;
                Invoke("canMove", 4);
                Invoke("respawnPos", 4);

			}
        }
		healthBar.value = NewPlayerHealth;
    }

	public void respawnPos()
    {
		transform.position = new Vector3(-34.25f,-0.186f,-10.01f);
	}

    public void canMove()
    {
        this.GetComponent<InputController>().enabled = true;
    }

    void Move()
    {
        print("Player Move Function");

        float moveSpeed = runSpeed;

        if(playerInput.IsWalking)
        {
            moveSpeed = runSpeed;
        }

        if(playerInput.IsSprinting)
        {
            moveSpeed = SprintSpeed;
        }

        if (playerInput.IsCrouched)
        {
            moveSpeed = crouchSpeed;
        }

        Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed * Time.deltaTime);
        MoveController.Move(direction);
    }

    public int GetPlayerStealthProfile()
    {
        if (IsWalking)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }


    void LookAround()
    {
        print("Player mouse function");

        Vector2 direction = new Vector2(playerInput.Vertical * runSpeed, playerInput.Horizontal * runSpeed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<AIExample>().OnAware();
        }
    }
	public float RetHealth(){
		return NewPlayerHealth;
	}

    public void HitPause()
    {
        if(MouseControl.LockMouse == false)
        {
            MouseControl.LockMouse = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            MouseControl.LockMouse = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
