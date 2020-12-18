using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MyScript : MonoBehaviour {

	//public AudioSource source { get { return GetComponent<AudioSource> (); }}
	//public Button btn { get { return GetComponent<Button> (); } }
	public AudioClip sonido;
	AudioSource audio;
	public bool alreadyplayed = false;
	//float timeRemaining = 5;

	public class Firebasedata
    {
        public bool[] estado = new bool[9];
        public string[]  hora = new string[9];
        
        
    }
    public Firebasedata myData = new Firebasedata();

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();

		FirebaseDatabase.DefaultInstance
            .GetReference("dispositivo")
            .ValueChanged += HandleValueChanged;
		audio = GetComponent<AudioSource>();
		//btn.onClick.AddListener (PlaySound);
	}
	void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        for (int i = 0; i <= 3; i++)
        {
            Debug.Log("antes");
            myData.estado[i] = bool.Parse(args.Snapshot.Child($"casilla-00{i+1}").Child("historial").Child("estado").Value.ToString());
            Debug.Log(myData.estado[i]);
        }
		if (Array.Exists(myData.estado, element => element == true))
		{
			Debug.Log("pues entro al array");
			audio.PlayOneShot(sonido, 1);
		}
        
    }

	void Update()
    {
		
		
				
	}
	
}
