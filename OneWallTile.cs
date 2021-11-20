using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "One Wall Tile", menuName = "One Wall Tile", order = 358)]
public class OneWallTile : ScriptableObject
{
    //0 = up, 1 = right, 2 = down, 3 = left
    [SerializeField]
    private Sprite[] cleanTiles = default;

    //0 = wand oben mit diagonale links unten und rechts unten
    //1 = wand oben mit diagonale links unten
    //2 = wand oben mit diagonale rechts unten
    [SerializeField]
    private Sprite[] upWallTiles = default;

    //0 = wand rechts mit diagonale links oben und links unten
    //1 = wand rechts mit diagonale links oben
    //2 = wand rechts mit diagonale links unten
    [SerializeField]
    private Sprite[] rightWallTiles = default;

    //0 = wand unten mit diagonale links oben und rechts oben
    //1 = wand unten mit diagonale links oben
    //2 = wand unten mit diagonale rechts oben
    [SerializeField]
    private Sprite[] downWallTiles = default;

    //0 = wand links mit diagonale rechts oben und rechts unten
    //1 = wand links mit diagonale rechts oben
    //2 = wand links mit diagonale rechts unten
    [SerializeField]
    private Sprite[] leftWallTiles = default;


    //Ach du heilige Scheisse...
    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();

        //Wand oben
        if (GameStats.map[posX, posY + 1] == 1)
        {
            if (GameStats.map[posX - 1, posY - 1] == 1 && GameStats.map[posX + 1, posY - 1] == 1)
                temp.sprite = upWallTiles[0];
            else if (GameStats.map[posX - 1, posY - 1] == 1)
                temp.sprite = upWallTiles[1];
            else if (GameStats.map[posX + 1, posY - 1] == 1)
                temp.sprite = upWallTiles[2];
            else temp.sprite = cleanTiles[0];
        }
        //Wand rechts
        else if (GameStats.map[posX + 1, posY] == 1)
        {
            if (GameStats.map[posX - 1, posY + 1] == 1 && GameStats.map[posX - 1, posY - 1] == 1)
                temp.sprite = rightWallTiles[0];
            else if (GameStats.map[posX - 1, posY + 1] == 1)
                temp.sprite = rightWallTiles[1];
            else if (GameStats.map[posX - 1, posY - 1] == 1)
                temp.sprite = rightWallTiles[2];
            else temp.sprite = cleanTiles[1];
        }
        //Wand unten
        else if (GameStats.map[posX, posY - 1] == 1)
        {
            if (GameStats.map[posX - 1, posY + 1] == 1 && GameStats.map[posX + 1, posY + 1] == 1)
                temp.sprite = downWallTiles[0];
            else if (GameStats.map[posX - 1, posY + 1] == 1)
                temp.sprite = downWallTiles[1];
            else if (GameStats.map[posX + 1, posY + 1] == 1)
                temp.sprite = downWallTiles[2];
            else temp.sprite = cleanTiles[2];
        }
        //Wand links
        else
        {
            if (GameStats.map[posX + 1, posY + 1] == 1 && GameStats.map[posX + 1, posY - 1] == 1)
                temp.sprite = leftWallTiles[0];
            else if (GameStats.map[posX + 1, posY + 1] == 1)
                temp.sprite = leftWallTiles[1];
            else if (GameStats.map[posX + 1, posY - 1] == 1)
                temp.sprite = leftWallTiles[2];
            else temp.sprite = cleanTiles[3];
        } 

        return temp;
    }
}
