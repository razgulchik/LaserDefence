using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

    [SerializeField] List<GameObject> bonusType;

    public GameObject ReturnBonusType()
    {
        return bonusType[Random.Range(0,bonusType.Count)];
    }

}
