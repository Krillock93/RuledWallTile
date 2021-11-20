using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Ruled Wall Tile", menuName = "Ruled Wall Tile", order = 357)]
public class RuledWallTile : ScriptableObject
{
    [SerializeField]
    private OneWallTile oneWallTiles;
    [SerializeField]
    private TwoWallTile twoWallTiles;
    [SerializeField]
    private ThreeWallTile threeWallTiles;
    [SerializeField]
    private Tile fourWallTile;
    [SerializeField]
    private OneDiagTile oneDiagonalTiles;
    [SerializeField]
    private TwoDiagTile twoDiagonalTiles;
    [SerializeField]
    private ThreeDiagTile threeDiagonalTiles;
    [SerializeField]
    private Tile fourDiagonalTile;
    [SerializeField]
    private Tile fillerTile;

    private int neighbourCounter;
    private int diagonalCounter;

    public Tile SelectRuledTile(int x, int y)
    {
        neighbourCounter = 0;
        diagonalCounter = 0;

        CheckNeighbours(x, y);

        if (neighbourCounter == 0)
        {
            if (diagonalCounter == 0)
                return fillerTile;
            else if (diagonalCounter == 1)
                return oneDiagonalTiles.SelectTile(x, y);
            else if (diagonalCounter == 2)
                return twoDiagonalTiles.SelectTile(x, y);
            else if (diagonalCounter == 3)
                return threeDiagonalTiles.SelectTile(x, y);
            else return fourDiagonalTile;
        }
        else if (neighbourCounter == 1)
            return oneWallTiles.SelectTile(x, y);
        else if (neighbourCounter == 2)
            return twoWallTiles.SelectTile(x, y);
        else if (neighbourCounter == 3)
            return threeWallTiles.SelectTile(x, y);
        else return fourWallTile;
    }

    //Nachbarn der angegebenen Position checken
    //neighbourCounter + diagonalCounter sind hier gesetzt
    private void CheckNeighbours(int posX, int posY)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                //eigene position überspringen
                if (i == 0 && j == 0)
                    continue;

                if(IsValidPosition(posX + i, posY +j))
                {
                    //links und rechts vom Ausgangspunkt checken
                    if(posY + j == posY)
                    {
                        if(posX+i != posX)
                        {
                            if (GameStats.map[posX + i, posY + j] == 1)
                                neighbourCounter++;
                        }
                    }

                    //oben und unten vom Ausgangspunkt checken
                    if (posX + i == posX)
                    {
                        if (posY + j != posY)
                        {
                            if (GameStats.map[posX + i, posY + j] == 1)
                                neighbourCounter++;
                        }
                    }

                    //bleiben noch die 4 diagonalen offen
                    if(GameStats.map[posX + i, posY + j] == 1)
                    {
                        diagonalCounter++;
                    }
                }
            }
        }
    }

    //Überprüfen ob gülitge position
    private bool IsValidPosition(int x, int y)
    {
        if (x < 0 || x > GameStats.map.GetLength(0))
            return false;
        else if (y < 0 || y > GameStats.map.GetLength(1))
            return false;

        return true;
    }
}


