using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public Sprite imgX, imgO;
    private char symbol = 'X';

    private SpriteRenderer sr;
    private int row, col;        // used only to determine wins, unused otherwise
    GameManager gameKeeper;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameKeeper = FindObjectOfType<GameManager>();
        // Tile12-> row1, col2
        char r = gameObject.name[4];
        char c = gameObject.name[5];

        row = int.Parse("" + r);
        col = int.Parse("" + c);
    }

    void OnMouseDown() {

        // check if space is available
        // if so,
        // set to X or O
		
        gameKeeper.Set(row, col, symbol); // sets piece on main board, and checks for win

	}
    
}
