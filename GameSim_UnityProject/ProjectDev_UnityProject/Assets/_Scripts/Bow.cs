﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Item
{
   public GameObject arrow;
   public float fireRate = 1f;
   public AudioClip shotClip;
   AudioSource shotSound;
   private Direction player;
   private float timer = 0f;

   BoxCollider2D boxCollider;

   private void Awake ( )
   {
      boxCollider = GetComponent<BoxCollider2D>();
      player = GetComponent<Direction>();
      shotSound = GetComponent<AudioSource>();
   }

   public override void Use ( )
   {
      if ( timer >= fireRate)
      {
         Shoot();
         timer = 0f;
      }
   }

   private void Update ( )
   {
      timer += Time.deltaTime;
      //if (Input.GetKeyDown(KeyCode.P))
      //   Use();
   }

   private void Shoot ( )
   {
      Vector3 dir = new Vector3();
      Vector3 offset = new Vector3();
      switch ( player.GetFacing() )
      {
         case Direction.Facing.Up :
            //dir.z = 90f;
            dir.z = 0f;
            offset.y = boxCollider.size.y * 4.25f;
            break;
         case Direction.Facing.Left:
            //dir.z = 180f;
            dir.z = 90f;
            offset.x = -boxCollider.size.x * 4.25f;
            break;
         case Direction.Facing.Down:
            //dir.z = -90f;
            dir.z = 180f;
            offset.y = -boxCollider.size.y * 4.5f;
            break;
         case Direction.Facing.Right:
            //dir.z = 0f;
            dir.z = -90f;
            offset.x = boxCollider.size.x * 4.25f;
            break;
      }

      shotSound.clip = shotClip;
      shotSound.Play();
      GameObject bolt = Instantiate(arrow, player.transform.position + offset, Quaternion.identity) as GameObject;
      bolt.transform.rotation = Quaternion.Euler(dir);
   }

   private void OnTriggerEnter2D ( Collider2D collision )
   {
      if ( player == null)
      {
         player = collision.GetComponent<Direction>();
      }
   }
}
