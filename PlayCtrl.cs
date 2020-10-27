using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCtrl : MonoBehaviour
{
    public float movespeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public Animator anim;


    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

   

    }

    void FixedUpdate()
    {
        
        if (movement.x != 0 || movement.y != 0)
        {

            MovePos();           
            MoveWeaponCheckAnim();            
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot.ChangWeapon += 1;
            ChageWeaponAnim();
            Debug.Log(Shoot.ChangWeapon);
        }

        if (movement.x == 0 && movement.y == 0)
        {
            WeaponIdelAnim();
        }

    }

    void MovePos()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        rb.rotation = angle;        
    }

    void ChageWeaponAnim()
    {
        switch (Shoot.ChangWeapon)
        {
            case 0:
                anim.SetInteger("changewp", 0);
                break;
            case 1:
                anim.SetInteger("changewp", 1);
                break;
            case 2:
                anim.SetInteger("changewp", 2);
                break;
        }
    }

    void MoveWeaponCheckAnim()
    {
        switch (Shoot.ChangWeapon)
        {
            case 0:
                anim.SetInteger("state", 1);
                break;
            case 1:
                anim.SetInteger("stateii", 1);
                break;
            case 2:
                anim.SetInteger("stateiii", 1);
                break;

        }
    }
    void WeaponIdelAnim()
    {
        switch (Shoot.ChangWeapon)
        {
            case 0:
                anim.SetInteger("state", 0);
                break;
            case 1:
                anim.SetInteger("stateii", 0);
                break;
            case 2:
                anim.SetInteger("stateiii", 0);
                break;
        }
    }
}
