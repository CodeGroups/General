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
        public string[]  hora = new string[9];
        
        
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

        // FirebaseDatabase.DefaultInstance
        //     .GetReference("dispositivo")
        //     .Child("casilla-001")
        //     .Child("historial")
        //     .ValueChanged += HandleValueChanged;
        
        FirebaseDatabase.DefaultInstance
            .GetReference("dispositivo")
            .ValueChanged += HandleValueChanged;

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        DataSnapshot dataSnapshot = args.Snapshot;
        DataSnapshot dataSnapshot2 = args.Snapshot;
        Debug.Log(dataSnapshot.GetRawJsonValue());
        //Toma los datos de Json
        myData = JsonUtility.FromJson<Firebasedata>(dataSnapshot.GetRawJsonValue());
        Debug.Log(myData.estado);

        for (int i = 0; i <= 3; i++)
        {
            Debug.Log("antes");
            myData.estado[i] = bool.Parse(args.Snapshot.Child($"casilla-00{i+1}").Child("historial").Child("estado").Value.ToString());
            Debug.Log(myData.estado[i]);
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log("A ver que sale "+myData.estado[i]);
        // lights[0].SetActive(myData.estado[0]);
        foreach(GameObject light in lights)
        {
            Debug.Log("ya funciona "+i);
            light.SetActive(myData.estado[i]);
            if (i< 3)
            {
               i++; 
            }
        }
    }
}
