using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    public Transform takip_kupu;

    public void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, takip_kupu.position, Time.deltaTime * 3.0f);
    }


}
