using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private Rigidbody rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

	private Joystick joyStick;
	private JoyButton joyButton;

    private bool isGrounded;
    private Vector3 velocity;


	private void Awake()
	{
#if UNITY_ANDROID
		//DO ANDROID
		MobileStickInit();
#endif
		rb = GetComponent<Rigidbody>();
	}

	private void LookRotation()
	{
		if (rb.velocity != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
		}
	}

	public void Movement()
	{
        isGrounded = false;

		Debug.Log("DefaultStandalone Movement");

		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector3 _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
		LookRotation();

        ///<summary>
        ///Vanaf hier wordt de jump geimplementeerd, nog geen overleg gehad
        ///over hoe we dat bij de andere platforms implementeren
        /// </summary>

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        rb.AddForce(velocity, ForceMode.Acceleration);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Add a vertical force to the player.
            isGrounded = false;
            rb.AddForce(new Vector3(0f, jumpForce, 0f));
        }
    }

	public void WebMovement()
	{
		Debug.Log("WebGL Movement");

		isGrounded = false;

		Debug.Log("DefaultStandalone Movement");

		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector3 _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
		LookRotation();

		///<summary>
		///Vanaf hier wordt de jump geimplementeerd, nog geen overleg gehad
		///over hoe we dat bij de andere platforms implementeren
		/// </summary>

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		velocity.y += gravity * Time.deltaTime;

		rb.AddForce(velocity, ForceMode.Acceleration);

		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			// Add a vertical force to the player.
			isGrounded = false;
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}

	//DO XBOX
	public void ControllerMovement()
	{
		Debug.Log("Controller Movement");
		LookRotation();
	}
	
	//DO ANDROID
	//Initialize
	private void MobileStickInit()
	{
		joyStick = FindObjectOfType<Joystick>();
		joyButton = FindObjectOfType<JoyButton>();
	}

	//JoyStick Movement Android
	public void MobileMovement()
	{
		Debug.Log("Mobile Movement");

		//Vector3 _movement = new Vector3(joyStick.Horizontal, rb.velocity.y, joyStick.Vertical);
		//rb.AddForce(_movement * speed, ForceMode.VelocityChange);
		//LookRotation();


		isGrounded = false;

		float _movementHorizontal = joyStick.Horizontal;
		float _movementVertical = joyStick.Vertical;

		Vector3 _movement = new Vector3(_movementHorizontal, 0.0f, _movementVertical);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
		LookRotation();

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		velocity.y += gravity * Time.deltaTime;

		rb.AddForce(velocity, ForceMode.Acceleration);

		if (isGrounded && joyButton.pressed)
		{
			// Add a vertical force to the player.
			isGrounded = false;
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}
}