using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExternalListReader))]
public class BlinkManager_External : MonoBehaviour
{
    public ExternalListReader reader;
    public bool addBlinkComponentIfMissing = true;

    [Header("Blink settings")]
    public float blinkInterval = 0.5f;
    public int repeat = 8;

    [Header("Shelf Highlight")]
    public Color shelfColor = Color.yellow;

    void Awake()
    {
        if (reader == null) reader = GetComponent<ExternalListReader>();
    }

    public void LoadListAndBlink()
    {
        var data = reader.ReadFromJson();
        if (data == null || data.identifiers == null || data.identifiers.Count == 0)
        {
            Debug.LogWarning("BlinkManager_External: lista vazia");
            return;
        }

        HashSet<GameObject> boxesToBlink = new HashSet<GameObject>();
        HashSet<GameObject> shelvesToHighlight = new HashSet<GameObject>();

        foreach (var rawEntry in data.identifiers)
        {
            if (!rawEntry.Contains(",")) continue;

            string[] split = rawEntry.Split(',');
            if (split.Length != 2) continue;

            string boxTag = split[0].Trim();
            string shelfTag = split[1].Trim();

            // 1) Encontra prateleiras
            GameObject[] shelfObjs = null;
            try { shelfObjs = GameObject.FindGameObjectsWithTag(shelfTag); }
            catch { continue; }

            if (shelfObjs == null || shelfObjs.Length == 0)
                continue;

            // 2) Encontra caixas
            GameObject[] boxObjs = null;
            try { boxObjs = GameObject.FindGameObjectsWithTag(boxTag); }
            catch { continue; }

            if (boxObjs == null || boxObjs.Length == 0)
                continue;

            // 3) Validação real: caixa deve ser FILHA da prateleira
            foreach (var shelf in shelfObjs)
            {
                foreach (var box in boxObjs)
                {
                    if (box.transform.IsChildOf(shelf.transform))
                    {
                        boxesToBlink.Add(box);
                        shelvesToHighlight.Add(shelf);
                    }
                }
            }
        }

        // 4) Destacar prateleiras válidas
        foreach (var shelf in shelvesToHighlight)
        {
            var r = shelf.GetComponent<Renderer>();
            if (r == null)
                r = shelf.GetComponentInChildren<Renderer>();

            if (r != null)
                r.material.color = shelfColor;

            // Agora o mesmo para SpriteRenderer
            var s = shelf.GetComponent<SpriteRenderer>();
            if (s == null)
                s = shelf.GetComponentInChildren<SpriteRenderer>();

            if (s != null)
                s.color = shelfColor;
        }

        // 5) Piscas as caixas válidas
        foreach (var box in boxesToBlink)
        {
            var bl = box.GetComponent<Blinker>();
            if (bl == null && addBlinkComponentIfMissing)
                bl = box.AddComponent<Blinker>();

            if (bl != null)
            {
                bl.blinkInterval = blinkInterval;
                bl.repeat = repeat;
                bl.StartBlink();
            }
        }

        Debug.Log($"Blink: {boxesToBlink.Count} caixas piscando, {shelvesToHighlight.Count} prateleiras destacadas.");
    }
}
