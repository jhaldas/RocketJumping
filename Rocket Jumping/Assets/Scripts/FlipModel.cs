using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FlipModel : MonoBehaviour
{
    public Transform weapon;
    public Transform playerHolder;
    float xScale;

    public TwoBoneIKConstraint rightHandIK;
    public TwoBoneIKConstraint leftHandIK;

    public Transform rightHint;
    public Transform leftHint;

    public Transform frontHandGrip;
    public Transform backHandGrip;

    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Rotation " + weapon.rotation.z);
        if(weapon.rotation.z < -0.7 || weapon.rotation.z > 0.7)
        {
            playerHolder.transform.localScale = new Vector3(-playerHolder.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // frontHandGrip.transform.localScale = new Vector3(-frontHandGrip.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // backHandGrip.transform.localScale = new Vector3(-backHandGrip.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // rightHandIK.data.target = frontHandGrip;
            // leftHandIK.data.target = backHandGrip;
            
        }
        else
        {
            playerHolder.transform.localScale = new Vector3(playerHolder.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // frontHandGrip.transform.localScale = new Vector3(frontHandGrip.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // backHandGrip.transform.localScale = new Vector3(backHandGrip.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            // rightHandIK.data.target = frontHandGrip;
            // leftHandIK.data.target = backHandGrip;
        }
    }
}
