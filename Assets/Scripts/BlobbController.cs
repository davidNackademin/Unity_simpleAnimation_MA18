using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbController : MonoBehaviour
{

    public GameObject particles;

    Animator animator;

    int rollTriggerHash = Animator.StringToHash("roll");
    int pressedTimeHash = Animator.StringToHash("blobPressedTime");
    int blinkTriggerHash = Animator.StringToHash("blink");
    float pressedTime = 0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        particles.SetActive(false);

        ReactStateBehaviour[] reactStates = animator.GetBehaviours<ReactStateBehaviour>();

        foreach(ReactStateBehaviour reactState in reactStates)
        {
            reactState.blobbController = this;
        }


    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if( hit.collider != null && hit.collider.gameObject == gameObject)
            {
                pressedTime += Time.deltaTime;
            }
        }
        else
        {
            pressedTime = 0;
        }

        animator.SetFloat(pressedTimeHash, pressedTime);
    }

    public void SwitchPartikles()
    {
        particles.SetActive(!particles.activeInHierarchy);
    }


    private void OnMouseDown()
    {
        //Play roll animation

        //animator.Play("Roll");

        //animator.SetTrigger(rollTriggerHash);

       // animator.SetTrigger(blinkTriggerHash);

    }


}
