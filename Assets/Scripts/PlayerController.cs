using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private CharacterController character;
    Vector3 moveinput;
    [SerializeField]
    private float mouseSenstivity;
    [SerializeField]
    private bool invertX, invertY;
    Vector2 mouseInput;
    private float gravity = 9.81f;
    public LayerMask groundMask;
    Animator anim;
   
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var horiMove = transform.right * horizontal;
        var verMove = transform.forward * vertical;
        moveinput = horiMove + verMove;
        moveinput *= moveSpeed;
        anim.SetFloat("Blend", moveinput.x);

       
        moveinput.y += Physics.gravity.y * gravity * Time.deltaTime;

        character.Move(moveinput * Time.deltaTime);
        //camera rotation using mouseinput
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSenstivity;
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);



    }
}