using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootingOffset;
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRGrabbable Grabbable = this.gameObject.GetComponent<OVRGrabbable>();
        if (Grabbable.isGrabbed)
        {
            if (Grabbable != null)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, Grabbable.grabbedBy.m_controller))
                {
                    GameObject currentBullet = Instantiate(Bullet, ShootingOffset.transform.position, ShootingOffset.transform.rotation);
                    currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2000, ForceMode.Force);
                    Audio.Play();
                }
            }
        }
    }
}

