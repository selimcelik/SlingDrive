using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoint2DController : MonoBehaviour
{
    GameObject[] playerGO;
    FixedJoint2D fixedJoint2;
    Rigidbody2D rb;

    [SerializeField]
    float distance = 2f;

    float calculatedDistance;

    [SerializeField]
    private GameObject lineGeneratorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectsWithTag("Player");
        rb = playerGO[0].GetComponent<Rigidbody2D>();
        fixedJoint2 = gameObject.GetComponent<FixedJoint2D>();
        
    }
    // Update is called once per frame
    void Update()
    {

        calculatedDistance = Vector2.Distance(transform.position, playerGO[0].transform.position);

        if (distance > calculatedDistance)
        {
            if (Input.GetMouseButton(0))
            {
                fixedJoint2.connectedBody = rb;
                SpawnLineGenerator();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                fixedJoint2.connectedBody = null;
            }
        }
    }
    private void SpawnLineGenerator()
    {
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();
        var myPosition = transform.position;
        var playerPosition = playerGO[0].transform.position;
        myPosition.z = playerPosition.z = - 1;
        lRend.SetPosition(0, myPosition);
        lRend.SetPosition(1, playerPosition);
        Destroy(lRend, 0.4f);

    }
}


