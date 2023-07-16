using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer()) // Player can be seen.
        {
            // Lock the lose player timer and increment the move and shot timers.
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            // Move the enemy to a random position after a random time.
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 4));
                moveTimer = 0;
            }
        }
        else // Lost sight of the player
        {
            losePlayerTimer += Time.deltaTime;

            if (losePlayerTimer > 8)
            {
                // Change to the search state.
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        // Store reference to the gun barrel.
        Transform gunBarrel = enemy.gunBarrel;

        // Instantiate a new bullet.
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);

        // Calculate the direction to the player.
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;

        // Add force rigidbody of the bullet.
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;

        Debug.Log("Shoot");
        shotTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
