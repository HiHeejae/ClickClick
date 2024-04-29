using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType charType;

    private enum CharacterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }


    private void ChangeOutfit()
    {
        foreach (SpriteResolver resolver in resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());


            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            Debug.Log($"sprite : {sprite}");

        }
    }
}
