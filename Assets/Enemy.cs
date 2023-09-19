using Assets.Code;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    int currentHealth;
    public float speed;
    private Transform player;
    private Animator animator;
    public int attackDamage;
    public int expiriens;

    public float startTime;
    private float timeBtw;
    bool isDiee;
    public string nameAnimationDie;

    void Start()
    {
        timeBtw = startTime;
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            isDiee = true;
        }
        if (isDiee == false && (Mathf.Abs(player.position.x - transform.position.x) > 1f || Mathf.Abs(player.position.y - transform.position.y) > 1f))
        {
            animator.SetBool("Attack", false);
            animator.SetBool("isRun", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(isDiee == false)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("Attack", true);
        }
        if (isDiee == true)
        {
            //Wolf_Diemnm
            //if (namDie == 0)
            //{
            //    animator.Play(nameAnimationDie);
            //    namDie = 1;
            //}
            if (timeBtw <= 0)
            {
                gameObject.SetActive(false);
            }
            else { timeBtw -= Time.deltaTime; }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDiee == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerControler.TakeDamage(attackDamage);

            }

        }
    }

        public void TakeDamage(int damage)
        {
            if (isDiee == false)
            {

                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
            }

        }
        void Die()
        {
            animator.SetBool("isDie", true);
            isDiee = true;
            animator.SetBool("isRun", false);
            animator.SetBool("Attack", false);
            animator.Play(nameAnimationDie);

            Quest.Expiriens += expiriens;
            //if (Quest.Expiriens == 250)
            //{
            //    Quest.idQuest[10] = true;
            //}
        }
    
}
