using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getTestDataFromFirebase : MonoBehaviour
{
    
    public GameObject lightObject;
    // Start is called before the first frame update
    void Start()
    {
        lightObject.SetActive(false);
        Debug.Log("Initializing");
        /*
        FirebaseDatabase.DefaultInstance
            .GetReference("medicine").Child("med-001")
            .GetValueAsync().ContinueWith(task => {
              
                if (task.IsFaulted)
                {
                  // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    Debug.Log(snapshot.GetRawJsonValue());
                }
            });
            */

        
        FirebaseDatabase.DefaultInstance
            .GetReference("medicine").Child("med-001")
            .ValueChanged += HandleValueChanged;
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot

        DataSnapshot dataSnapshot = args.Snapshot;
        if (dataSnapshot != null)
        {
            lightObject.SetActive(true);
            Debug.Log(dataSnapshot.GetRawJsonValue());
        }
        
    }

}
