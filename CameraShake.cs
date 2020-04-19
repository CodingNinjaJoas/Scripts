using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    public Animator cameraAnim;
    public float waitTime;
    public float waitTimeBig;
    public IEnumerator Shake()
    {
        cameraAnim.SetBool("Shake",true);
        yield return new WaitForSeconds(waitTime);
        cameraAnim.SetBool("Shake",false);
    }
    public IEnumerator BigShake()
    {
        cameraAnim.SetBool("BigShake", true);
        yield return new WaitForSeconds(waitTimeBig);
        cameraAnim.SetBool("BigShake", false);
    }


    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

    }

}
