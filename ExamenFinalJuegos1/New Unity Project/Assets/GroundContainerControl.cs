using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContainerControl : MonoBehaviour
{

    [Header("Ground Prefab Variables")]
    public GameObject groundPrefab;

    [Header("Ground Position Variables")]
    private Vector2 posCurrentGround;
    public float posXInitial;
    public float posYInitial;
    public float posXSeparation;

    [Header("All Ground Container Variables")]
    public int numbOfGrounds;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGround();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateGround()
    {
        for (int i = 0; i < numbOfGrounds; ++i)
        {
            posCurrentGround = new Vector2(posXInitial + posXSeparation*i,posYInitial);
            GameObject tmp = Instantiate(groundPrefab, posCurrentGround, transform.rotation);
            tmp.transform.SetParent(this.transform);
        }
    }
}
