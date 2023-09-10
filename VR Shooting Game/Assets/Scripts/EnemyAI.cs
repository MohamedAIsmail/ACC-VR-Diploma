using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public int HP;
    public Animator animator;
    private Transform player;
    public Slider healthBar;
    float timer;

    public float damageDelay = 0.3f;
    private float currentDamageDelay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount)
    {
        if (Time.time < currentDamageDelay)
            return;

        currentDamageDelay = Time.time + damageDelay;

        HP -= damageAmount;

        if (HP <= 0)
        {
            Destroy(healthBar);
            animator.SetTrigger("Die");
            GetComponent<CapsuleCollider>().enabled = false;

            Destroy(gameObject, 5);
        }
        else
        {
            animator.SetTrigger("Hit");
            AudioManager.instance.Play("Enemy Hit");
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }

    void Update()
    {
        healthBar.value = HP;
        Vector3 dir = player.position - this.gameObject.transform.position;
        dir.y = 0;
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
    }


}
