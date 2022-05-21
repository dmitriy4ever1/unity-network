using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix : MonoBehaviour
{
    [HideInInspector]
    public static Block[,,] blocks = new Block[3, 3, 3];

    static bool red = false;
    static Matrix me;
    public  Text label;
 
    public static bool gameOver = false;

    private void Awake()
    {
        me = GetComponent<Matrix>();
    }
    public static void OnRemoteMessage(int x, int y, int z, char who)
    {
        //print("X:" + x + " y:" + y + " z:" + z);
        if (who == 'r')
        {
            blocks[x, y, z].PaintRed();
            me.label.text = "Turn: Blue";
            Block.collor = 2;
        }
        else
        {
            blocks[x, y, z].PaintBlue();
            me.label.text = "Turn: Red";
            Block.collor = 1;
        }
        blocks[x, y, z].selected = true;

        if (Center.first == true)
        {
            Center.first = false;
        }
    }

    static void Winner()
    {
        gameOver = true;

        if (red==false)
            me.label.text = "Red Won!!!";
        else
            me.label.text = "Blue Won!!!";

        print("there is a winner");
       
    }
    public static void Change(int x,int y,int z,int rb)
    {
       // blocks[x, y, z] = rb;
      //  Check();
    }


    static void Check()
    {
        int totalRed = 0;
        int totalBlue = 0;
        /*
        for (int z = 0; z < 3; z++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (blocks[x, y, z] == 1)
                        totalRed++;
                    if (blocks[x, y, z] == 2)
                        totalBlue++;
                }
                Totalbr();
            }
        }
        for (int z = 0; z < 3; z++)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (blocks[x, y, z] == 1)
                        totalRed++;
                    if (blocks[x, y, z] == 2)
                        totalBlue++;
                }
                Totalbr();
            }
        }
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    if (blocks[x, y, z] == 1)
                        totalRed++;
                    if (blocks[x, y, z] == 2)
                        totalBlue++;
                }
                Totalbr();
            }
        }

        for (int z = 0; z < 3; z++)
        {
            for (int dig = 0; dig < 3; dig++)
            {

                if (blocks[dig, dig, z] == 1)
                    totalRed++;

                if (blocks[dig, dig, z] == 2)
                    totalBlue++;
            }
            Totalbr();
        }
        for (int z = 0; z < 3; z++)
        {
            for (int dig = 0; dig < 3; dig++)
            {

                if (blocks[2-dig, dig, z] == 1)
                    totalRed++;

                if (blocks[2-dig, dig, z] == 2)
                    totalBlue++;
            }
            Totalbr();
        }

       //full block diagonals
        for (int dig = 0; dig < 3; dig++)
        {
            if (blocks[dig, dig, dig] == 1)
                totalRed++;

            if (blocks[dig, dig, dig] == 2)
                totalBlue++;
        }
        Totalbr();
      
        for (int dig = 0; dig < 3; dig++)
        {
            if (blocks[2-dig, dig, dig] == 1)
                totalRed++;

            if (blocks[2-dig, dig, dig] == 2)
                totalBlue++;
        }
        Totalbr();
        
        for (int dig = 0; dig < 3; dig++)
        {
            if (blocks[dig, 2-dig, dig] == 1)
                totalRed++;

            if (blocks[dig, 2-dig, dig] == 2)
                totalBlue++;
        }
        Totalbr();

        for (int dig = 0; dig < 3; dig++)
        {
            if (blocks[dig, dig, 2-dig] == 1)
                totalRed++;

            if (blocks[dig, dig, 2-dig] == 2)
                totalBlue++;
        }
        Totalbr();
        void Totalbr()
        {
            if (totalRed == 3)
            {
                red = true;
                Winner();
            }
            if (totalBlue == 3)
            {
                red = false;
                Winner();
            }
            totalRed = 0;
            totalBlue = 0;
        }
        */
    }
}
