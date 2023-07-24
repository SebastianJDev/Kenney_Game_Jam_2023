using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float InputX,InputY;
    public Vector2 MoveInput;
    public float speed;
    public Rigidbody2D rb;
    PlantaController CurrentPLanta;
    Animator anim;
    GameObject Triger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   
    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        MoveInput = new Vector2(InputX, InputY);

        if (Input.GetKeyDown(KeyCode.E))
        {
           Triger.GetComponent<Fuentes>().Drop();
           ManagerUI.Instance.ActualizarTextoAgua($"{Triger.GetComponent<Fuentes>().Usos}/6");
        }
        if(MoveInput == Vector2.zero)
        {
            anim.SetBool("Run", false);
        }

    }
    private void FixedUpdate()
    {
        Move();
        
    }

    public void Move()
    {
        rb.MovePosition(rb.position + MoveInput * speed * Time.fixedDeltaTime);
        anim.SetBool("Run",true);

    }
    public void RegarDesdePlayer()
    {
        CurrentPLanta.Regar();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Interactable":
                Triger = collision.gameObject;
                ManagerUI.Instance.ActivarUIItem();
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Interactable":
                Triger = collision.gameObject;
                ManagerUI.Instance.ActualizarTextoAgua($"{Triger.GetComponent<Fuentes>().Usos}/6");
                break;
            case "Plantar":
                CurrentPLanta = collision.GetComponent<PlantaController>();
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Interactable":
                Triger = null;
                ManagerUI.Instance.DesactivarUIItem();
                break;
        }
    }
}
