using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    GameObject oponentTurn;
    public static bool won = false;
    public bool selected = false;
    public int x;
    public int y;
    public int z;
    public Text label;
    protected string send = "";
    protected static Color RED = new Color(1f, 0f, 0f, 0.8f);
    protected static Color BLUE = new Color(0f, 0f, 1f, 0.8f);
    protected static Color INVIS = new Color(1.0f, 1.0f,1.0f, 0.0f);
    protected static Color TRANSPERENT = new Color(1.0f, 1.0f,1.0f, 0.5f);

    protected Renderer rend;
    static int MyColor = 0;
    public static int collor = 1;
    // Modify transparenct or opacity (alpha) of a cube:
    // choose a pair of keys to modify these - 
    // should be applicable to an empty cube only
    // (only for empty cubes)

    void Start()
    {
        send = x+","+y+","+z;
        rend = GetComponent<Renderer>();
        Matrix.blocks[x, y, z] = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown("e") && selected == false)
            rend.material.color = INVIS;
        if (Input.GetKeyUp("e") && selected == false)
            rend.material.color = TRANSPERENT;
       
    }

    public void PaintRed()
    {
        rend.material.color = RED;
    }

    public void PaintBlue()
    {
        rend.material.color = BLUE;
    }
    void OnMouseDown()
    {
        if (MyColor == 0 && Center.first == true)
        {
            MyColor = 1;
            
            print("you are red" + MyColor);
        }
        if (MyColor == 0 && Center.first == false)
        {
            MyColor = 2;
            print("you are blue" + MyColor);

        }
        print("curent color num is: " + collor + "    Your color num is: " + MyColor);

        if (collor == MyColor)
        {


            if (Matrix.gameOver)
                return;
            if (selected)
                return;


            if (collor == 1)
            {
                //rend.material.color = RED;
                // Matrix.Change(x, y, z, 2);
                send = send + ",r";
            }
            if (collor == 2)
            {
                //rend.material.color = BLUE;
                // Matrix.Change(x, y, z, 1);
                send = send + ",b";
            }

            WsClient.Submit(send);
            //  pressed = true;
            //  red = !red;
            //  TurnChange();

        }
    }
   


    /*
        public void ChangeColor()
        {
            oponentTurn = GameObject.Find("Matrix/" + send);

        }
    */

}
