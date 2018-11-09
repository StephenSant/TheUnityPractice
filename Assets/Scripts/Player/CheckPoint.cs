using UnityEngine;
using System.Collections;
    //this script can be found in the Component section under the option Character Set Up 
    //CheckPoint
    [AddComponentMenu("FirstPerson/Player/CheckPoint")]
    public class CheckPoint : MonoBehaviour
    {
        #region Variables
        [Header("Check Point Elements")]
        public GameObject curCheckpoint;//GameObject for our currentCheck
        [Header("Character Handler")]
        public CharacterHandler charH;//character handler script that holds the players health
        #endregion
        #region Start
        private void Start()
        {
            charH = GetComponent<CharacterHandler>();//the character handler is the component attached to our player

            #region Check if we have Key
            if (PlayerPrefs.HasKey("SpawnPoint"))//if we have a save key called SpawnPoint
            {
                curCheckpoint = GameObject.Find(PlayerPrefs.GetString("SpawnPoint"));//then our checkpoint is equal to the game object that is named after our save file
                transform.position = curCheckpoint.transform.position;//our transform.position is equal to that of the checkpoint
            }
            #endregion
        }
        #endregion
        #region Update
        private void Update()
        {
            //respawning in CharacterHandler
        }
        #endregion
        #region OnTriggerEnter
        private void OnTriggerEnter(Collider other)//Collider other
        {
            if (other.tag == "Checkpoint")//if our other objects tag when compared is CheckPoint
            {
                curCheckpoint = other.gameObject;//our checkpoint is equal to the other object
                PlayerPrefs.SetString("SpawnPoint", curCheckpoint.name);//save our SpawnPoint as the name of that object
                Debug.Log("You have entered:" + curCheckpoint.name);
            }
        }
        #endregion
    }





