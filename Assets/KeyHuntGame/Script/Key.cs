using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum keyType
{
    None = -1,
    Key1,
    Key2,
    Key3
}

public class Key : MonoBehaviour
{

    public keyType Type = keyType.None;

}
