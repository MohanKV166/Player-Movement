using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGrounded;
    public LayerMask ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(transform.position, 0.25f, ground));
    }
}
