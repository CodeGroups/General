using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MyScript : MonoBehaviour {

	public AudioClip sonido;
	AudioSource audio;
	public bool alreadyplayed = false;

	public class Firebasedata
    {
        public bool[] estado = new bool[9];
    }
    public Firebasedata myData = new Firebasedata();

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();

		FirebaseDatabase.DefaultInstance
            .GetReference("dispositivo")
            .ValueChanged += HandleValueChanged;
		audio = GetComponent<AudioSource>();
	}
	void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        for (int i = 0; i < 9; i++)
        {
            myData.estado[i] = bool.Parse(args.Snapshot.Child($"casilla-00{i+1}").Child("estado").Value.ToString());
        }
		if (Array.Exists(myData.estado, element => element == true))
		{
			StartCoroutine(playaudio());
		}
        
    }
	IEnumerator playaudio() {
      
      	WaitForSeconds wait = new WaitForSeconds(10);
      	for(int i = 0; i < 6; i++) {
			
			audio.PlayOneShot(sonido, 1);
        	yield return wait; //Pausa el loop durante 3 seg
      	}
   }
}
