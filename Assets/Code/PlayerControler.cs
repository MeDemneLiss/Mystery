using Assets.Code;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float speed =2;
    private Vector2 direction;
    public Animator animator;
    private Rigidbody2D rb;
    public bool isAtack = false;
    public float attackRange;
    public int attackDamage = 10;
    public int maxHealth;
    public static int setHealth;
    public VectorValue pos;
    private static float timeBtw = 2;
    public static bool neuizv = false;

    void Start()
    {
        transform.position = pos.initialValue;
        setHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y); 
        animator.SetFloat("Speed", direction.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, direction, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(setHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        if(Quest.idQuest[11] == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            direction.x = -9f;
            direction.y = 14.5f;
            Quest.idQuest[11] = false;
        }
        if (Quest.idQuest[12] == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            direction.x = 12f;
            direction.y = -2f;
            Quest.idQuest[10] = true;
            Quest.idQuest[12] = false;
        }
        if (timeBtw <= 0 )
        {
            neuizv = false;
        }
        else { timeBtw -= Time.deltaTime; }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rb.position + Vector2.up * 0.1f, attackRange, LayerMask.GetMask("Enemy"));

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        //*Time.fixedDeltaTime
    }
    public static void TakeDamage(int attackDamage)
    {
        if(neuizv == false)
        {
            setHealth -= attackDamage;
            neuizv = true;
            timeBtw = 2;
        }
    }
}
