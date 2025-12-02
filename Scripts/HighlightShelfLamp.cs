using UnityEngine;

public class HighlightShelfLamp : MonoBehaviour
{
    public ShelfManager shelfManager;

    void Start()
    {
        // Nova forma recomendada de encontrar componentes no Unity 6
        if (shelfManager == null)
            shelfManager = FindFirstObjectByType<ShelfManager>();

        if (shelfManager == null)
            Debug.LogError("ShelfManager não encontrado na cena! Adicione um ou arraste no Inspector.");
    }

    public void HighlightItem(string itemName)
    {
        if (shelfManager == null)
        {
            Debug.LogError("ShelfManager não está referenciado!");
            return;
        }

        // 1. Encontrar a prateleira correspondente ao item
        if (!shelfManager.itemShelfMap.ContainsKey(itemName))
        {
            Debug.LogError("Item não encontrado no dicionário: " + itemName);
            return;
        }

        string shelfTag = shelfManager.itemShelfMap[itemName];

        // 2. Limpar todas as lâmpadas
        ClearAllLamps();

        // 3. Acender a lâmpada da prateleira correta
        GameObject shelf = null;

        try
        {
            shelf = GameObject.FindGameObjectWithTag(shelfTag);
        }
        catch
        {
            Debug.LogError("A tag '" + shelfTag + "' não existe no projeto!");
            return;
        }

        if (shelf == null)
        {
            Debug.LogError("Prateleira com a tag '" + shelfTag + "' não encontrada na cena.");
            return;
        }

        Transform lampTransform = shelf.transform.Find("Lamp");

        if (lampTransform == null)
        {
            Debug.LogError("A prateleira '" + shelf.name + "' não possui um objeto filho chamado 'Lamp'.");
            return;
        }

        MeshRenderer lampRenderer = lampTransform.GetComponent<MeshRenderer>();

        if (lampRenderer != null)
        {
            lampRenderer.material.color = Color.yellow; // acende a lâmpada
        }
        else
        {
            Debug.LogError("O objeto Lamp não possui MeshRenderer!");
        }
    }

    void ClearAllLamps()
    {
        // Limpa apenas prateleiras que possuem a tag geral "Shelf"
        GameObject[] shelves = GameObject.FindGameObjectsWithTag("Shelf");

        foreach (GameObject shelf in shelves)
        {
            Transform lampTransform = shelf.transform.Find("Lamp");
            if (lampTransform == null) continue;

            MeshRenderer lampRenderer = lampTransform.GetComponent<MeshRenderer>();
            if (lampRenderer == null) continue;

            lampRenderer.material.color = Color.white; // cor padrão desligada
        }
    }
}
