using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getState : MonoBehaviour
{
    public class Firebasedata
    {
        public bool status;
        public string  time;
        
        
    }
    public Firebasedata myData = new Firebasedata();
    public GameObject[] lights = new GameObject[9];

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject light in lights)
        {
            light.SetActive(myData.status);

        }

        FirebaseDatabase.DefaultInstance
            .GetReference("historial")
            .Child("med-001")
            .ValueChanged += HandleValueChanged;
        // 

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        DataSnapshot dataSnapshot = args.Snapshot;
        Debug.Log(dataSnapshot.GetRawJsonValue());
        //Toma los datos de Json
        myData = JsonUtility.FromJson<Firebasedata>(dataSnapshot.GetRawJsonValue());
        Debug.Log(myData.status);
    }
    

    // Update is called once per frame
    void Update()
    {
        lights[0].SetActive(myData.status);
        // foreach(GameObject light in lights)
        // {
        //     light.SetActive(myData.status);
            
        // }
    }
}
