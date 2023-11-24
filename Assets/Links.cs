using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;

public class Links: MonoBehaviour
{
    private static Links instance;

    public Transform WeightStash_Forward;
    public Transform WeightStash_Back;

    private void Awake()
    {
        instance = this;
    }

    //private Links()
    //{ }

    public static Links GetInstance()
    {
        return instance;
    }
}