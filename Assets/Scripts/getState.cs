using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getState : MonoBehaviour
{
    public int i=0;
    public class Firebasedata
    {
        public bool[] estado = new bool[9];
        public int  cantcasillas = 0;
    }
    public Firebasedata myData = new Firebasedata();
    public GameObject[] lights = new GameObject[9];

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject light in lights)
        {
            light.SetActive(false);

        }
        FirebaseDatabase.DefaultInstance
            .GetReference("dispositivo")
            .ValueChanged += HandleValueChanged;

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {

        for (int i = 0; i < 9; i++)
        {
            
            myData.estado[i] = bool.Parse(args.Snapshot.Child($"casilla-00{i+1}").Child("estado").Value.ToString());
            
        }
        foreach(GameObject light in lights)
        {
            //Debug.Log("ya funciona "+i);
            light.SetActive(myData.estado[i]);
            i++; 
        }
        //light.SetActive(myData.estado[i]);
        
    }
}
