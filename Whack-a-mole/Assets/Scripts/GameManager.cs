﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    MoleManager moleManager;
    /* como ainda nao sei que inputs utilizar, por agora ponho todos*/
    AndroidInput androidInput;
    InputManager inputManager;
    public Camera mainCamera;
    /*-----------------------------------------------------*/

	void Start () {

        /* retorna o objecto do tipo MoleManager (se existir) */
        moleManager = FindObjectOfType<MoleManager>();
        if (moleManager == null) Debug.LogError("MOLE MANAGER IS NULL");

        /* cria um novo objecto do tipo InputManager */
        inputManager = FindObjectOfType<InputManager>();
        if (inputManager == null) Debug.LogError("CANT FIND THE INPUT MANAGER");

	}
	
	void Update () {
        Touch[] touches = inputManager.TouchesInAFrame;
        if(touches.Length > 0)
        {
            foreach(Touch touch in touches)
            {
                //devolve a posiçaõ do toque em world coordinates
                Vector3 pos = mainCamera.ScreenToWorldPoint(touch.position);

                foreach (MoleBox mole in moleManager.locations)
                {
                    //se a posiçaõ do toque faz overlap com a Box Collider da Mole, muda a cor do quadrado (para reconhecer que houve um toque)
                    if (mole.boxCollider.OverlapPoint(pos)) mole.BoxWasHit();
                }

            }
        }
		
	}
}
