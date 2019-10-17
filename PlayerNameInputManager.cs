using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NewBehaviourScript : MonoBehaviour
{
 
    public void SetPlayerName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            print("Name is empty");
            return;
        }
        PhotonNetwork.NickName = name;
    }
}
