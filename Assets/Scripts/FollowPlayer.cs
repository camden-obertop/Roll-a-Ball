using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerBall;

    private void Update()
    {
        transform.position = playerBall.transform.position;
    }
}
