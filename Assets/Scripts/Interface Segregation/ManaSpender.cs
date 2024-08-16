using UnityEngine;

public class ManaSpender 
{
    // This method manages the mana spending when a spell is cast by a character or entity.
    public void CastSpell(Transform caster, int manaCost)
    {
        // caster: The Transform component of the entity that is casting the spell.
        // Using Transform to access and get the mana user component.
        var manaUser = caster.GetComponent<IManaUser>();

        // If the caster does not have an IManaUser component, exit the method.
        if(manaUser == null) return;

        // If IManaUser is present, spend the specified amount of mana.
        manaUser.SpendMana(manaCost);

        // Log the remaining mana amount to the console.
        Debug.Log(manaUser.Mana);
    }
}
