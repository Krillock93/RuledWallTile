using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Two Diagonal Tile", menuName = "Two Diagonal Tile", order = 362)]
public class TwoDiagTile : ScriptableObject
{

    //straights
    //0 = (up + left) + (up + right) ,
    //1 = (up + right) + (down + right),
    //2 = (down + right) + (down + left) ,
    //3 = (down + left) + (up + left),
    [SerializeField]
    private Sprite[] crossings = default;

    //crossings
    //0 = (up + left) + (down + right) ,
    //1 = (up + right) + (down + left)
    [SerializeField]
    private Sprite[] straights = default;

    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();
        //straights
        if (GameStats.map[posX - 1, posY + 1] == 1 && GameStats.map[posX + 1, posY + 1] == 1)
            temp.sprite = crossings[0];
        else if (GameStats.map[posX + 1, posY + 1] == 1 && GameStats.map[posX + 1, posY - 1] == 1)
            temp.sprite = crossings[1];
        else if (GameStats.map[posX + 1, posY - 1] == 1 && GameStats.map[posX - 1, posY - 1] == 1)
            temp.sprite = crossings[2];
        else if (GameStats.map[posX - 1, posY - 1] == 1 && GameStats.map[posX - 1, posY + 1] == 1)
            temp.sprite = crossings[3];

        //crossings
        else if (GameStats.map[posX - 1, posY + 1] == 1 && GameStats.map[posX + 1, posY - 1] == 1)
            temp.sprite = straights[0];
        else temp.sprite = straights[1];

        return temp;
    }
}
