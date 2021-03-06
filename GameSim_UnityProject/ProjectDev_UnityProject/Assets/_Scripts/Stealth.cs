﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : Item
{
   bool inStealth = false;
   public float stealthMultiplier = 2f;
   public GameObject stealthSprite;

   private void Awake()
   {
      stealthSprite.SetActive(false);
   }

   public override void Use()
   {
      if (!inStealth)
      {
         inStealth = true;
         stealthSprite.SetActive(true);
         EnemyMovement.detectRange /= stealthMultiplier;
         //Debug.Log("Enemy detection range: " + EnemyMovement.detectRange);
         EnemyArcher.detectRange /= stealthMultiplier;
         //Debug.Log("Archer detection range: " + EnemyArcher.detectRange);
         EnemyArcher.attackRange /= stealthMultiplier;
         //Debug.Log("Archer attack range: " + EnemyArcher.attackRange);
      }
      else if (inStealth)
      {
         inStealth = false;
         stealthSprite.SetActive(false);
         EnemyMovement.detectRange *= stealthMultiplier;
         //Debug.Log("Enemy detection range: " + EnemyMovement.detectRange);
         EnemyArcher.detectRange *= stealthMultiplier;
         //Debug.Log("Archer detection range: " + EnemyArcher.detectRange);
         EnemyArcher.attackRange *= stealthMultiplier;
         //Debug.Log("Archer attack range: " + EnemyArcher.attackRange);
      }
   }
}
