using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDooky : MonoBehaviour {
    public Animator anim;
    public float woon_MaxHp = 10f;
    public float woon_CerHp;
    public float delay = 1f;

    float countdown;


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
            

            if (countdown <= 0) {
                countdown = 0;
                Destroy (gameObject);
            }
        }
    }

}
