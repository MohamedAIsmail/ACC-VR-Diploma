using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float time = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-20f, 10f), 0, Random.Range(-25f, 25f)), Enemy.transform.rotation);
            time = 5;
        }
    }
}
