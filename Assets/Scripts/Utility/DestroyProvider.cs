using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProvider : MonoBehaviour
{
    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void DestroyObjectAfter1Sec(GameObject obj)
    {
        Destroy(obj, 1f);
    }

    public void DestroyObjectAfter3Sec(GameObject obj)
    {
        Destroy(obj, 3f);
    }

    public void DestroyObjectAfter5Sec(GameObject obj)
    {
        Destroy(obj, 5f);
    }
}
