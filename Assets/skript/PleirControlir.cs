using System.Collections;
using UnityEngine;

public class PleirControlir : MonoBehaviour
{
    public float speed;
    public float jamp;
    private Rigidbody2D rb;
    private SpriteRenderer SR;
    private bool srBool;
    private Animator an;
    private bool anBool;
    private int isGraund;
    private bool isClic;
    private bool isBloc;
    private MysicalControlir MC;
    private TextControler TC;
    public Light lightt;
    public float startLight;

    public bool invers;
    public static Transform pleirTransform { get; set; }
    public static MysicalControlir MCS { get; set; }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ ������ �����
        if (collision.gameObject.tag == "litic")
        {
            LightNlatform lit = collision.gameObject.GetComponent<LightNlatform>();
            lit.litic();
        }else if (collision.gameObject.tag == "end")
        {
            end END = collision.gameObject.GetComponent<end>();
            if (!END.over)
            {
                SenMenedgersic.levelUp();
            }
            else
            {
                SenMenedgersic.res();
            }
        }
        // ������ ��� ���� ������
        else if (collision.gameObject.tag == "trigNrig")
        {
            rb.AddForce(new Vector2(speed * 0.5f, jamp * 1.5f), ForceMode2D.Impulse);
            isGraund -= 1;
        }
        // ������ � ������
        else if (collision.gameObject.tag == "bocsik")
        {
            ConfigObzect ConfigO = collision.gameObject.GetComponent<ConfigObzect>();
            // ������ ������
            if (ConfigO.text != "")
            {
                float time = TC.textVivod(ConfigO.text);
                MC.TEXT(time);
                StartCoroutine(blocControlir(time-2));
            }
            // ��������� �����(snapshots)
            if (ConfigO.TinZvuca != -1)
                MC.SetActiveParameters(ConfigO.TinZvuca);
            // ����������� ���������
            if (ConfigO.bloc)
            {
                if (ConfigO.blocAnti) blocControlir();
                else blocControlir(ConfigO.blocArgument);
            }
            // ���������� ���������
            if (ConfigO.lightt != -1)
                lightt.intensity = ConfigO.lightt;
            // ������������� ����
            if (ConfigO.nota != -1)
                MC.sigrat(ConfigO.nota, collision.gameObject.transform);
            // ����������� ��������
            if (ConfigO.revors)
                invers = !invers;


            Destroy(collision.gameObject);
        }
    }



    // ������� �����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Graund")
        {
            rb.Sleep();
            isGraund += 1;
            MC.sag();
        }
        else if(collision.gameObject.tag == "xvatatil")
        {
            colisiaList CL = collision.gameObject.GetComponent<colisiaList>();
            if (CL != null)
                CL.col = true;
        }
    }

    // �� ������� �����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Graund")
            isGraund -= 1;
    }

    private void Awake()
    {
        pleirTransform = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        MC = GetComponent<MysicalControlir>();
        TC = GetComponent<TextControler>();
        MCS = MC;
    }

    void Start()
    {
        //transform.position = new Vector2(3, 5);
        lightt.intensity = startLight;
    }

    void Update()
    {
        if (isGraund<0) isGraund = 0;

        if (isBloc) return;
        float movX = Input.GetAxisRaw("Horizontal");
        if (isClic) movX = 1;
        if (invers) movX *= -1;
        if (!(isGraund>0)) movX = 0;

        // ������� ������
        if(srBool != movX < 0 && movX !=0)
        {
            SR.flipX = movX < 0;
            srBool = movX < 0;
        }
        
        // ��������
        if ((movX != 0) != anBool)
        {
            an.SetBool("idot", movX != 0);
            anBool = movX != 0;
        }

        // ������
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGraund>0)
        {
            rb.AddForce(new Vector2(speed* movX, jamp), ForceMode2D.Impulse);
            isGraund -= 1;
        }

        // ���� �����
        if (movX != 0)
            MC.sag();

        transform.Translate(Vector2.right * movX * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.R))           ////////////////////////////////////////////////////
        //    transform.position = new Vector2(3,5);
    }

    public void Clic(bool B)
    {
        isClic = B;
    }

    // ��������� ���������� ������� �� time ���
    public IEnumerator blocControlir(float time, bool tin = false)
    {
        isBloc = true ^ tin;
        yield return new WaitForSeconds(time);
        isBloc = false ^ tin;
    }

    // ��������� ���������� �������
    public void blocControlir()
    {
        isBloc = !isBloc;
    }

    // ��������� ���������� �������
    public void blocControlir(bool tin)
    {
        isBloc = tin;
    }
}

