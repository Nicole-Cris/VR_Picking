using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public Dictionary<string, string> itemShelfMap = new Dictionary<string, string>()
    {
        { "Caixa1", "WP_001" },
        { "Caixa2", "WP_001" },
        { "Caixa3", "WP_001" },
        { "Caixa4", "Shelf_02" },
        { "Caixa5", "Shelf_03" },
        { "Caixa6", "Shelf_03" },
        { "Caixa7", "Shelf_04" },
        { "Caixa8", "Shelf_04" },
        { "Caixa9", "Shelf_05" },
        { "Caixa10", "Shelf_05" }
    };
}

