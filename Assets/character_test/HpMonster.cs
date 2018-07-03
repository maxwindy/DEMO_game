using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpMonster : MonoBehaviour {
    public Animator anim;
    public float woon_MaxHp = 10f;
    public float woon_CerHp;
    public ParticleSystem woonDeadeffect;
    public ParticleSystem woonDeadeffect1;
    public float delay = 1f;

    float countdown;
    bool explode = false;

    void Start () {
        anim = GetComponentInChildren<Animator> ();
        countdown = delay;
        woon_CerHp = woon_MaxHp;
    }
    public void TakeDamage(float amount)
    {
        if (woon_CerHp <= 0) return;
        woon_CerHp -= amount;
        anim.SetTrigger("hit");
    }

    void Update () {
        if (woon_CerHp <= 0) {
            anim.SetBool("isDead", true);
            countdown -= Time.deltaTime;
            

            if (countdown <= 0 && !explode) {
                countdown = 0;
                Instantiate (woonDeadeffect.gameObject, transform.position,transform.rotation);
                Instantiate (woonDeadeffect1.gameObject, transform.position,transform.rotation);
                explode = true;
                Destroy (gameObject);
            }
        }
    }

}
