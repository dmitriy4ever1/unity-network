using UnityEngine;
using UnityEngine.UI;

// our center piece - not easily clickable
// so we let the 'U' button select it
public class Center : Block
{
    public static Transform ORIGIN;
    public static bool first = true;
    string send = "1,1,1";


    private void Start()
    {
        send = x + "," + y + "," + z;
        ORIGIN = transform;
        rend = GetComponent<Renderer>();
        Matrix.blocks[x, y, z] = this;
    }

    // Modify transparenct or opacity (alpha) of a cube:
    // choose a pair of keys to modify these - 
    // should be applicable to an empty cube only
    // (only for empty cubes)
    
    void Update()
    {
        if (Input.GetKeyDown("e") && selected == false)
            rend.material.color = INVIS;
        if (Input.GetKeyUp("e") && selected == false)
            rend.material.color = TRANSPERENT;
        if (Block.won == false)
        {
            if (Input.GetKeyDown("space") && first == false)
            {
                if (selected == false)
                {
                    if (Block.collor == 1)
                    {
                        rend.material.color = RED;
                        label.text = "Turn: Blue";
                        Matrix.Change(1, 1, 1, 2);
                        send = send + ",r";

                    }
                    if (Block.collor == 2)
                    {
                        rend.material.color = BLUE;
                        label.text = "Turn: Red";
                        Matrix.Change(1, 1, 1, 1);
                        send = send + ",b";

                    }
                    WsClient.Submit(send);

                    selected = true;
                }
            }
        }
    }
    
}
