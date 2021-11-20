using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Two Wall Tile", menuName = "Two Wall Tile", order = 359)]
public class TwoWallTile : ScriptableObject
{
    //0 = left + up, 1 = right + up, 2 = right+down, 3 = left + down
    [SerializeField]
    private Sprite[] corners = default;
    // 0 = Wall is left + right, 1 = Wall is up and down
    [SerializeField]
    private Sprite[] crossings = default;
    //0 = left up + right down
    //1 = right up + left down
    //2 = right down + left up
    //3 = left down + right up
    [SerializeField]
    private Sprite[] cornersWithDiagonal = default;

    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();

        //Corners
        if (GameStats.map[posX - 1, posY] == 1 && GameStats.map[posX, posY + 1] == 1)
        {
            if(GameStats.map[posX +1,posY -1] == 1)
                temp.sprite = cornersWithDiagonal[0];
            else temp.sprite = corners[0];
        }
        else if (GameStats.map[posX + 1, posY] == 1 && GameStats.map[posX, posY + 1] == 1)
        {
            if (GameStats.map[posX - 1, posY - 1] == 1)
                temp.sprite = cornersWithDiagonal[1];
            else temp.sprite = corners[1];
        }
        else if (GameStats.map[posX + 1, posY] == 1 && GameStats.map[posX, posY - 1] == 1)
        {
            if (GameStats.map[posX - 1, posY + 1] == 1)
                temp.sprite = cornersWithDiagonal[2];
            else temp.sprite = corners[2];
        }
        else if (GameStats.map[posX - 1, posY] == 1 && GameStats.map[posX, posY - 1] == 1)
        {
            if (GameStats.map[posX + 1, posY + 1] == 1)
                temp.sprite = cornersWithDiagonal[3];
            else temp.sprite = corners[3];
        }
        //crossings
        else if (GameStats.map[posX - 1, posY] == 1 && GameStats.map[posX + 1, posY] == 1)
            temp.sprite = crossings[0];
        else temp.sprite = crossings[1];

        return temp;
    }
}

