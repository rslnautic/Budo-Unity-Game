﻿using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	// Here we store the hash tags for various strings used in our animators.
	public static int movementInDir = Animator.StringToHash("LookingInMovementDir");
	public static int movementSpeed = Animator.StringToHash("MovementAbsolute");
	public static int jump = Animator.StringToHash("Jump");
	public static int held = Animator.StringToHash("inground");
	public static int win = Animator.StringToHash("win");
}