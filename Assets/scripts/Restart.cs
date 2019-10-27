using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Vector3 tempVector;
    public int tempCount;
    private Vector3 defaultVector;
    // Start is called before the first frame update
    void Start()
    {
        defaultVector = transform.position;
        transform.position = defaultVector;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = Pathmaker.floorList.Count - 1; i > -1; i--)
        {
            if (Pathmaker.floorList[i] == null)
                Pathmaker.floorList.RemoveAt(i);
        }
        Pathmaker.sum = Vector3.zero;
        for(int i = 0; i < Pathmaker.floorList.Count; i++)
        {
            Pathmaker.sum += Pathmaker.floorList[i].transform.position;
        }
        tempVector = Pathmaker.sum;
        tempCount = Pathmaker.floorList.Count;
        transform.position = new Vector3(tempVector.x / tempCount, transform.position.y, tempVector.z / tempCount);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Pathmaker.totalFloor = 0;
            Pathmaker.sum = Vector3.zero;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
