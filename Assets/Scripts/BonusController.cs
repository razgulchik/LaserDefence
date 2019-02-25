using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

    [SerializeField] List<GameObject> bonusType;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public GameObject ReturnBonusType()
    {
        return bonusType[Random.Range(0,bonusType.Count)];
    }

}
