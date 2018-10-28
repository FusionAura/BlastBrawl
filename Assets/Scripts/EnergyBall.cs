using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {
    //Who Shot the Projectile. I shouldn't hit the caster regardless if they touch it.
    public GameObject Shooter;
    private float ignorecol = 0;
    public int ShooterNum = 0;

    private void Update()
    {
        if (ignorecol < 10)
        {
            ignorecol += 1 * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != Shooter)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Floor" && ignorecol > 0.5)
        {
            Destroy(gameObject);
        }
    }
}
