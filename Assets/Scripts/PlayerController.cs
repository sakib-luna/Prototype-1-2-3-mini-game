using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnim;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

        if(verticalInput != 0)
        {
            playerAnim.SetBool("Static_b", true);
            playerAnim.SetFloat("Speed_f", verticalInput);
        }else if (verticalInput == 0)
        {
            playerAnim.SetFloat("Speed_f", 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
        }   
    }
}
