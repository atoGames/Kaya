using UnityEngine;

public class Player_Movement : MonoBehaviour {

    private Camera_Follow _Cam;

    private CharacterController _CharacterController;

    private Vector3 InputMovement;
    private Vector3 camTrnsformDirection;  // { get; protected set; }
    private Quaternion dirRotation;

    // Speed
    [SerializeField, Header (" Speed Player ")]
    private float m_Speed = 5f;
    [SerializeField]
    private float m_DSpeed = 10f;
    private float _NormalSpeed;
    public float turnSmoothing = 25f;

    // Gravity
    private float _Gravity = -9.81f;



    // Input
    private const string _Horizontal = "Horizontal";
    private const string _Vertical = "Vertical";

    void Start () {
        _CharacterController = GetComponent<CharacterController> ();

        _NormalSpeed = m_Speed;

        _Cam = FindObjectOfType<Camera_Follow> ();
    }
    void Update () {

        MovePlayer ();

    }

    private void MovePlayer () {
        // Run ?
        if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
            m_Speed = m_DSpeed;
        else
            m_Speed = _NormalSpeed;

        // Get Input
        InputMovement = new Vector3 (Input.GetAxis (_Horizontal), _Gravity   , Input.GetAxis (_Vertical) ) ;

        // Get Camera  Direction 
        camTrnsformDirection = _Cam.transform.TransformDirection(InputMovement);
        // Fix Y 
        var rotatePlayer = new Vector3(camTrnsformDirection.x, 0f, camTrnsformDirection.z );

        // Rotate Player
        if (rotatePlayer != Vector3.zero)
        {
            dirRotation = Quaternion.LookRotation(rotatePlayer);
            transform.rotation = Quaternion.Lerp( transform.rotation , dirRotation , turnSmoothing * Time.deltaTime);
        }

        // Move the Player
        _CharacterController.Move (camTrnsformDirection * m_Speed * Time.deltaTime);
    }
   
}