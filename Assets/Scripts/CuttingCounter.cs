using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Counter has no kitchen object
            if (player.HasKitchenObject())
            {
                //Player is carrying kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //counter has kitchen object
            if (player.HasKitchenObject())
            {
                //player is carrying kitchen object
            }
            else
            {
                //player is not carrying kitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject()) { 
            //Has a kitchen object
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
