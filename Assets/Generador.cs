﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.enemy;
using NPC.Ally;
using System;



public class Generador : MonoBehaviour
{
    GameObject ZombieMesh;
    GameObject Gente;
    GameObject Hero;
    CosasZombie datoZombi;
    CosasCiudadanos datoCiudadanos;
    readonly int minimo;
    const int maximo = 25;
    int cantbody;
    Text zombie;
    int numzombie;


    System.Random rn = new System.Random();

    public Generador()
    {
        minimo = rn.Next(5, 15);    //rango de creación

    }

    void Start()
    {                                 // generador de NPC
        cantbody = rn.Next(minimo, maximo);
        for (int i = 0; i < cantbody; i++)
        {
            if (rn.Next(0,2)==0)
            {                               // generador de zombis
                ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ZombieMesh.AddComponent<ZombieOp>();

                datoZombi = ZombieMesh.GetComponent<ZombieOp>().datosZombi;
                switch (datoZombi.colorEs)
                {
                    case CosasZombie.ColorZombie.magenta:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case CosasZombie.ColorZombie.green:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case CosasZombie.ColorZombie.cyan:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }


                Vector3 pos = new Vector3(rn.Next(-10, 10), 0, rn.Next(-10, 10));
                ZombieMesh.transform.position = pos;
                ZombieMesh.AddComponent<Rigidbody>();
                ZombieMesh.name = "Zombi";
            }
            else // generador de ciudadanos
            {
                Gente = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gente.AddComponent<CiudadanoOp>();
                Vector3 po = new Vector3(rn.Next(-20, 10), 0, rn.Next(10, 10));
                Gente.transform.position = po;
                Gente.AddComponent<Rigidbody>();
                Gente.name = "Gente";
            }
        }
       
        // generador hero 
        Hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Hero.AddComponent<MovimientoTeclado>();
        Hero.AddComponent<Hero>();
        Hero.AddComponent<Camera>(); 
        Hero.AddComponent<Rigidbody>();
        Hero.name = "Hero";


        numzombie = 0;
        foreach (ZombieOp zombie in Transform.FindObjectsOfType<ZombieOp>())
        {
            numzombie= 1;
        }
    }
      
    


}
