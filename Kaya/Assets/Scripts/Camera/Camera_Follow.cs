using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    private Transform _Transform;
    public Transform _Player;

    [SerializeField]
    private Vector3 m_OffsetCam;
    [SerializeField]
    private float m_SpeedPlayerFollow = 1.5f;

    [SerializeField]
    private float m_RotateSpeed = 60F;


    void Start () {
        _Transform = transform;
       // _Player = FindObjectOfType<Player>();

    }
    void LateUpdate()
    {

        Follow_Player();
        RotateCamera();
    }

    private void Follow_Player () {

        Vector3 posCam = _Player.position + m_OffsetCam;

        posCam.x = Mathf.Lerp( _Transform.position.x, posCam.x, m_SpeedPlayerFollow * Time.deltaTime) ;
        posCam.y = 0 ;
        posCam.z =  Mathf.Lerp ( _Transform.position.z, posCam.z, m_SpeedPlayerFollow * Time.deltaTime )  ;

        _Transform.position = posCam;

    }

    public void RotateCamera () {
            _Transform.Rotate ( Vector3.up, RotationDirection * Time.deltaTime * m_RotateSpeed, Space.World );
    }

    public int RotationDirection {
        get {
            bool m_Right = Input.GetKey (KeyCode.Q);
            bool m_Left = Input.GetKey (KeyCode.E);

            if (m_Left && m_Right)
                return 0;
            else if (m_Left && !m_Right )
                return -1;
            else if ( !m_Left && m_Right)
                return 1;
            else
                return 0;
        }
    }

}