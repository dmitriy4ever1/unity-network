using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// a variation of BoardManager from the VS Console exercise:
public class GameManager : MonoBehaviour {

    // keep color private as it is static, together with everything else
    public Color winningColor = Color.white;

    private static char[,] board = {     
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
    };   // empty at start
   
    public void Set(int row, int col, char c)
    {
        board[row, col] = c;
        CheckWin();
    }

    //////////////////////////////////////////////////////////////////////////
    /////// select winning gameobjects and paint them in winning color  //////
    //////////////////////////////////////////////////////////////////////////
    void Highlight(GameObject go, Color c)
    {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        sr.color = c;
    }

    void Highlight(string [] sequence) // highlight winning sequence of elements
    {
        foreach (string winningIndex in sequence)
        {
            GameObject winningTile = GameObject.Find("Tile" + winningIndex);
            Highlight(winningTile, winningColor);
        }
    }

    /////////////////////////////////////////////////////////////////////////
    //////////  use code from BoardManager in 2DArray prject  ///////////////
    //////////////// to provide the needed functionality ////////////////////
    /////////////////////////////////////////////////////////////////////////

    int CheckRow(int rowID)
    {
        // call Matrix to check, passing it the board and rowID
        return 0;
    }
   
    void CheckWin () {

        // check rows 
        // check columns
        // check main and secondary diagonals
       
        int win = CheckRow(0);
        if(win == 3)
        {
            string[] winners = {  "00", "01", "02" };  // <- if first row wins, we highlight its top three tiles:
            Highlight(winners);
        }
        
    }

}
