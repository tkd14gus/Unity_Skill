using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCorutine());
    }

    IEnumerator CreateCorutine()
    {
        while (true)
        {
            yield return null;
            GameObject t_object = ObjectPooingManager.instance.GetQueue();
            t_object.transform.position = Vector3.zero;
        }
    }
}
