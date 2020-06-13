using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShack : MonoBehaviour
{
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offser = Vector3.zero;

    Quaternion m_originRot;

    // Start is called before the first frame update
    void Start()
    {
        m_originRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ShackeCroutine());
        } else if(Input.GetKeyDown(KeyCode.B))
        {
            StopAllCoroutines();
            StartCoroutine(Reset());
        }
    }

    IEnumerator ShackeCroutine()
    {
        Vector3 t_originEuler = transform.eulerAngles;
        while(true)
        {
            float t_rotX = Random.Range(-m_offser.x, m_offser.x);
            float t_rotY = Random.Range(-m_offser.y, m_offser.y);
            float t_rotZ = Random.Range(-m_offser.z, m_offser.z);

            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);
            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            while(Quaternion.Angle(transform.rotation, t_rot) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }

    IEnumerator Reset()
    {
        while(Quaternion.Angle(transform.rotation, m_originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
            yield return null;
        }
    }
}
