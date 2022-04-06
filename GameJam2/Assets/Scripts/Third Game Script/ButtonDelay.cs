using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelay : MonoBehaviour
{
    public GameObject target;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        target.SetActive(true);
    }
}
