using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    private Camera m_camera;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        m_camera = GetComponent<Camera>();
    }

    public void MoveCamera(float x, float y, float z)
    {
        m_camera.transform.position = new Vector3(x,y,z);
    }
}
