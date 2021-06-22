using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class ContinuesMovement : MonoBehaviour
{
    public float speed = 1;
    public float gravity = -9.81f;
    public LayerMask isGround;
    public float extraHeight = 0.2f;

    private float fallingspeed;
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;
    private XRRig rig;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }


    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);



    }
    private void FixedUpdate()
    {
        CapsuleFollowHeadSet();


        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * speed * Time.fixedDeltaTime);

        //gravity
        bool IsGrounded = CheckIfGrouded();
        if (IsGrounded)
            fallingspeed = 0;
        else
            fallingspeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * fallingspeed * Time.fixedDeltaTime);
    }
    void CapsuleFollowHeadSet()
    {
        character.height = rig.cameraInRigSpaceHeight + extraHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.y);
    }
    bool CheckIfGrouded()
    {
        Vector3 rayCast = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayCast, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, isGround);
        return hasHit; 
    }
}
