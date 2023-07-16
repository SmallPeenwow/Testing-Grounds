using UnityEngine;

[System.Serializable]
public class Item
{
    public abstract string GiveName();
    public virtual int MaxStacks()
    {
        return 30;
    }
    public virtual Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("UI/ItemImages/No Item Image Icon");
    }
}
